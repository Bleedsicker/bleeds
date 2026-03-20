using DataAccess.Repository;
using Domain;
using Microsoft.AspNetCore.Mvc;
using WebDevAPI.Dto;

namespace WebDevAPI.Controllers;

[ApiController]
[Route("[controller]")] 
public class OrderController : Controller
{
    private readonly IOrderRepository _orderRepository;
    private readonly IHttpClientFactory _httpClientFactory;

    public OrderController(IOrderRepository orderRepository, IHttpClientFactory httpClientFactory)
    {
        _orderRepository = orderRepository;
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet("GetCart")]
    public async Task<CartDto> GetCart(long userId)
    {
        var client = _httpClientFactory.CreateClient("WebDevAPI");

        var response = await client.GetAsync($"ShoppingCart/GetCart?userId={userId}");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<CartDto>();
        }

        return null;
    }

    [HttpGet("GetOrders")]
    public IActionResult GetOrders(long userId)
    {
        var orders = _orderRepository.GetOrders(userId);

        var result = orders.Select(o => new OrderDto
        {
            OrderId = o.OrderId,
            OrderDate = o.OrderDate,
            UserId = o.UserId,
            OrderProducts = o.OrderProducts?.Select(op => new OrderProductDto
            {
                ProductId = op.ProductId,
                Quantity = op.Quantity,
                UnitPrice = op.UnitPrice
            }).ToList() ?? new List<OrderProductDto>()
        }).ToList();

        return Ok(result);
    }

    [HttpGet("GetOrder")]
    public IActionResult GetOrder(long id)
    {
        var order = _orderRepository.GetOrder(id);
        if (order == null) return NotFound();

        var result = new OrderDto
        {
            OrderId = order.OrderId,
            OrderDate = order.OrderDate,
            UserId = order.UserId,
            OrderProducts = order.OrderProducts?.Select(op => new OrderProductDto
            {
                ProductId = op.ProductId,
                Quantity = op.Quantity,
                UnitPrice = op.UnitPrice
            }).ToList() ?? new List<OrderProductDto>()
        };

        return Ok(result);
    }

    [HttpPost("PostOrder")]
    public async  Task<IActionResult> PostOrder(long userId)
    {
        var client = _httpClientFactory.CreateClient("WebDevAPI");

        var response = await client.GetAsync($"ShoppingCart/GetCart?userId={userId}");

        var cart = await response.Content.ReadFromJsonAsync<CartDto>();

        if (cart == null || cart.Items.Count == 0)
        { 
            return BadRequest("Cart is empty");
        }

        var order = new Order
        {
            UserId = userId,
            OrderDate = DateTimeOffset.Now,
            OrderProducts = cart.Items.Select(item => new OrderProduct
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.Price
            }).ToList()
        };
        
        _orderRepository.AddOrder(order);
        await client.DeleteAsync($"ShoppingCart/GetCart?userId={userId}");

        return Ok(new OrderDto
        {
            OrderId = order.OrderId,
            OrderDate = order.OrderDate,
            UserId = order.UserId,
            OrderProducts = order.OrderProducts.Select(op => new OrderProductDto
            {
                ProductId = op.ProductId,
                Quantity = op.Quantity,
                UnitPrice = op.UnitPrice
            }).ToList()
        });
    }
}

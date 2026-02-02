using DataAccess.Repository;
using Domain;
using Microsoft.AspNetCore.Mvc;
using WebDevAPI.Dto;
using WebDevAPI.Infrastructure;

namespace WebDevAPI.Controllers;

[ApiController]
[Route("[controller]")] 
public class OrderController : Controller
{
    private readonly IOrderRepository _orderRepository;

    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
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
    public IActionResult PostOrder(long userId)
    {
        if (!CartStructure.Carts.TryGetValue(userId, out var cart) || cart.Items.Count == 0)
        { 
            return BadRequest("Cart is empry");
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
        CartStructure.Carts.TryRemove(userId, out _);

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

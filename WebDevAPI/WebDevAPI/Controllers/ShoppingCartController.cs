using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Collections.Concurrent;
using WebDevAPI.Dto;
using WebDevAPI.Infrastructure;

namespace WebDevAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ShoppingCartController : Controller
{
    private static ConcurrentDictionary<long, CartDto> _carts = CartStructure.Carts;
    private readonly IProductRepository _productRepository;

    public ShoppingCartController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    [HttpPost("AddToCart")]
    public IActionResult AddToCart([FromBody] AddToCartDto dto)
    {
        var product = _productRepository.GetProduct(dto.ProductId);

        var cart = _carts.GetOrAdd(dto.UserId, new CartDto { UserId = dto.UserId });

        var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == dto.ProductId);
        if (existingItem != null)
        {
            existingItem.Quantity++;
        }
        else
        {
            cart.Items.Add(new CartItemDto
            {
                ProductName = product.Name,
                ProductDescription = product.Description,
                Price = product.Price,
                ProductId = dto.ProductId,
                Quantity = 1
            });
        }

        return Ok(cart);
    }

    [HttpGet("GetCart")]
    public IActionResult GetCart(long userId)
    {
        if (_carts.TryGetValue(userId, out var cart))
            return Ok(cart);

        return Ok(new CartDto { UserId = userId });
    }

    [HttpPost("RemoveFromCart")]
    public IActionResult RemoveFromCart([FromBody] RemoveFromCartDto dto)
    {
        if (_carts.TryGetValue(dto.UserId, out var cart))
        {
            var item = cart.Items.FirstOrDefault(i => i.ProductId == dto.ProductId);
            if (item != null)
            {
                cart.Items.Remove(item);
            }

            if (!cart.Items.Any())
            {
                _carts.TryRemove(dto.UserId, out _);
            }
        }

        return Ok();
    }

    [HttpPost("ClearCart")]
    public IActionResult ClearCart([FromBody] ClearCartDto dto)
    {
        _carts.TryRemove(dto.UserId, out _);
        return Ok();
    }

    public record AddToCartDto(long UserId, long ProductId);
    public record RemoveFromCartDto(long UserId, long ProductId);
    public record ClearCartDto(long UserId);
}

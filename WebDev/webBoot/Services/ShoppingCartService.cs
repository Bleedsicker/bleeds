using DataAccess.Repository;
using Domain;
using System.Collections.Concurrent;
using WebDev.Models;
using System.Security.Claims;
namespace WebDev.Services;

public interface IShoppingCartService
{
    public void AddToCart(long userId, long productId, IProductRepository _productRepository);

    public void RemoveFromCart(long userId, long productId);

    ShoppingCartModel GetCart(long userId);

    public void ClearCart(long userId);

    public long GetUserId();
}

public class ShoppingCartService : IShoppingCartService
{
    private readonly ConcurrentDictionary<long, ShoppingCartModel> _carts = new();
    private readonly IHttpContextAccessor _HttpContextAccessor;

    public ShoppingCartService(IHttpContextAccessor httpContextAccessor)
    {
        _HttpContextAccessor = httpContextAccessor;
    }

    public void AddToCart(long userId, long productId, IProductRepository _productRepository)
    {
        var product = _productRepository.GetProduct(productId);
        if (product == null) return;

        var cart = _carts.GetOrAdd(userId, new ShoppingCartModel { UserId = userId });
        if (cart == null)
        {
            cart = new ShoppingCartModel();
        }
        var existingItem = cart.Items.FirstOrDefault(item => item.ProductId == productId);

        if (existingItem != null)
        {
            existingItem.Quantity++;
        }
        else
        {
            cart.Items.Add(new ShoppingCartItemModel
            {
                ProductId = product.Id,
                ProductName = product.Name,
                ProductDescription = product.Description,
                Price = product.Price,
                Quantity = 1
            });
        }
    }

    public void RemoveFromCart(long userId, long productId)
    {
        if (_carts.TryGetValue(userId, out var cart))
        {
            var removeItem = cart.Items.FirstOrDefault(item => item.ProductId == productId);

            if (removeItem != null)
            {
                cart.Items.Remove(removeItem);
            }
        }

        if (!cart.Items.Any())
        {
            _carts.TryRemove(userId, out _);
        }
    }

    public ShoppingCartModel GetCart(long userId)
    {
        if (_carts.TryGetValue(userId, out var cart))
        {
            return cart;
        }
        return new ShoppingCartModel { UserId = userId };
    }

    public void ClearCart(long userId)
    {
        _carts.TryRemove(userId, out _);
    }

    public long GetUserId()
    {
        var httpContext = _HttpContextAccessor.HttpContext;
        if (httpContext.User.Identity.IsAuthenticated)
        {
            var userIdClaim = httpContext.User.Claims.FirstOrDefault(o => o.Type == "UserId");
            if (userIdClaim != null && long.TryParse(userIdClaim.Value, out var userId))
            {
                return userId;
            }
        }

        throw new UnauthorizedAccessException();
    }
}

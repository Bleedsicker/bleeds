using System.Collections.Concurrent;
using WebDev.Models;
namespace WebDev.Services;

public interface IShoppingCartService
{
    public void AddToCart(string userId, long productId, string productName, string productDescription, decimal price);

    public void RemoveFromCart(string userId, long productId);

    ShoppingCartModel GetCart(string userId);

    public void ClearCart(string userId);
}

public class ShoppingCartService : IShoppingCartService
{
    private readonly ConcurrentDictionary<string, ShoppingCartModel> _carts = new();


    public void AddToCart(string userId , long productId, string productName, string productDescription, decimal price)
    {

        var cart = _carts.GetOrAdd(userId, new ShoppingCartModel { UserId = userId });
        var existingItem = cart.Items.FirstOrDefault(item => item.ProductId == productId);
        if (existingItem != null)
        {
            existingItem.Quantity++;
        }
        else
        {
            cart.Items.Add(new ShoppingCartItemModel
            {
                ProductId = productId,
                ProductName = productName,
                ProductDescription = productDescription,
                Price = price,
                Quantity = 1
            });
        }
    }

    public void RemoveFromCart(string userId, long productId)
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

    public ShoppingCartModel GetCart(string userId)
    {
        if (_carts.TryGetValue(userId, out var cart))
        {
            return cart;
        }
        return new ShoppingCartModel { UserId = userId };
    }

    public void ClearCart(string userId)
    {
        _carts.TryRemove(userId, out _);
    }

    //public decimal TotalPrice()
    //{
    //    return _shoppingCart.Sum(item => item.Price * item.Quantity);
    // }
}

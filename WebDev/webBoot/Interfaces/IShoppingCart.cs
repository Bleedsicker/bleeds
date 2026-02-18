using WebDev.Models;

namespace WebDev.Interfaces;

public interface IShoppingCartService
{
    Task AddToCart(long userId, long productId);

    Task RemoveFromCart(long userId, long productId);

    Task<ShoppingCartModel> GetCart(long userId);

    Task ClearCart(long userId);

    long GetUserId();
}

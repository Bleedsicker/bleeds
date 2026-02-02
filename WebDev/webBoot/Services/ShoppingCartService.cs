using WebDev.Models;
namespace WebDev.Services;

public interface IShoppingCartService
{
    Task AddToCart(long userId, long productId);

    Task RemoveFromCart(long userId, long productId);

    Task<ShoppingCartModel> GetCart(long userId);

    Task ClearCart(long userId);

    long GetUserId();
}

public class ShoppingCartService : IShoppingCartService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _HttpContextAccessor;

    public ShoppingCartService(IHttpContextAccessor httpContextAccessor, HttpClient httpClient)
    {
        _HttpContextAccessor = httpContextAccessor;
        _httpClient = httpClient;
    }

    public async Task AddToCart(long userId, long productId)
    {
        var response = await _httpClient.PostAsJsonAsync("/ShoppingCart/AddToCart", new
        {
            userId,
            productId
        });
        response.EnsureSuccessStatusCode();
    }
    
    public async Task RemoveFromCart(long userId, long productId)
    {
        var response = await _httpClient.PostAsJsonAsync("/ShoppingCart/RemoveFromCart", new
        {
            userId,
            productId
        });
        response.EnsureSuccessStatusCode();
    }

    public async Task<ShoppingCartModel> GetCart(long userId)
    {
        var cart = await _httpClient.GetFromJsonAsync<ShoppingCartModel>($"/ShoppingCart/GetCart?userId={userId}");

        return cart ?? new ShoppingCartModel { UserId = userId };
    }

    public async Task ClearCart(long userId)
    {
        var response = await _httpClient.PostAsJsonAsync("/ShoppingCart/ClearCart", new
        {
            userId
        });

        response.EnsureSuccessStatusCode();
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

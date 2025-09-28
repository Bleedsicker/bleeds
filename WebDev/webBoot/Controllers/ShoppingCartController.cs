using Microsoft.AspNetCore.Mvc;
using WebDev.Services;

namespace WebDev.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCart;

        public ShoppingCartController(IShoppingCartService shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            var userId = GetUserId();
            var cart = _shoppingCart.GetCart(userId);
            return View(cart);
        }

        public string GetUserId()
        {

            if (HttpContext.User.Identity.IsAuthenticated && !string.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                return HttpContext.User.Identity.Name;
            }

            var sessionId = HttpContext.Session.Id;
            return $"guest_{sessionId}";
        }

        public IActionResult AddToCart(long productId, string productName, string productDescription ,decimal price)
        {
            var userId = GetUserId();
            _shoppingCart.AddToCart(userId, productId, productName, productDescription ,price);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(string userId, long productId)
        {
            _shoppingCart.RemoveFromCart(userId, productId);

            return RedirectToAction("Index");
        }

        public IActionResult ClearCart(string userId)
        {
            _shoppingCart.ClearCart(userId);

            return RedirectToAction("Index");
        }
    }
}

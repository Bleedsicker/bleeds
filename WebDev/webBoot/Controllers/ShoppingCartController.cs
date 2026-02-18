using Microsoft.AspNetCore.Mvc;
using WebDev.Interfaces;

namespace WebDev.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCart;
        public ShoppingCartController(IShoppingCartService shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }
        public async Task<IActionResult> Index()
        {
            var userId = _shoppingCart.GetUserId();
            var cart = await _shoppingCart.GetCart(userId);
            return View(cart);
        }

        [HttpGet]
        public async Task<IActionResult> AddToCart(long productId)
        {

            var userId = _shoppingCart.GetUserId();
            await _shoppingCart.AddToCart(userId, productId);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveFromCart(long productId)
        {
            var userId = _shoppingCart.GetUserId();
            await _shoppingCart.RemoveFromCart(userId, productId);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ClearCart()
        {
            var userId = _shoppingCart.GetUserId();
            await _shoppingCart.ClearCart(userId);

            return RedirectToAction("Index");
        }
    }
}

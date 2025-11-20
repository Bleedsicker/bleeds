using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebDev.Services;

namespace WebDev.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IShoppingCartService _shoppingCart;

        private IProductRepository _productRepository;

        public ShoppingCartController(IShoppingCartService shoppingCart, IProductRepository productRepository)
        {
            _shoppingCart = shoppingCart;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var userId = _shoppingCart.GetUserId();
            var cart = _shoppingCart.GetCart(userId);
            return View(cart);
        }

        //public long GetUserId()
        //{

        //    if (HttpContext.User.Identity.IsAuthenticated)
        //    {
        //        if (string.IsNullOrWhiteSpace(User.Identity.Name) == false)
        //        {
        //            return int.Parse(User.Identity.Name);
        //        }
        //    }

        //    throw new UnauthorizedAccessException();
        //}

        [HttpGet]
        public IActionResult AddToCart(long productId)
        {
            var product = _productRepository.GetProduct(productId);

            var userId = _shoppingCart.GetUserId();
            _shoppingCart.AddToCart(userId, productId, _productRepository);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(long productId)
        {
            var userId = _shoppingCart.GetUserId();
            _shoppingCart.RemoveFromCart(userId, productId);

            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            var userId = _shoppingCart.GetUserId();
            _shoppingCart.ClearCart(userId);

            return RedirectToAction("Index");
        }
        
        //[HttpPost]
        //public IActionResult CreateOrder(Order order)
        //{
        //    var userId = GetUserId();
        //    var cart = _shoppingCart.GetCart(userId);
        //    if (!cart.Items.Any())
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    order.UserId = userId;
        //}


    }
}

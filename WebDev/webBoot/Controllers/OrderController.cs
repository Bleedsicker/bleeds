using DataAccess.Repository;
using Domain;
using Microsoft.AspNetCore.Mvc;
using WebDev.Services;

namespace WebDev.Controllers
{
    public class OrderController : Controller
    {
        private IShoppingCartService _shoppingCart;
        private IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository, IShoppingCartService shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            var userId = _shoppingCart.GetUserId();
            var orders = _orderRepository.GetOrders(userId);
            return View(orders);
        }

        public IActionResult Orders(long id)
        {
            var order = _orderRepository.GetOrder(id);
            return View(order);
        }

        [HttpGet]
        public IActionResult AddOrder()
        {
            var userId = _shoppingCart.GetUserId();
            var cart = _shoppingCart.GetCart(userId);
            if (cart == null)
            {
                RedirectToAction("Index", "ShoppingCart");
            }
            return View();
        }

        [HttpPost]
        public IActionResult PostOrder()
        {
            var userId = _shoppingCart.GetUserId();
            var cart = _shoppingCart.GetCart(userId);
            if (cart == null)
            {
                return RedirectToAction("Index", "ShoppingCart");
            }

            var order = new Order();
            order.UserId = userId;
            order.OrderDate = DateTime.Now;
            order.OrderProducts = cart.Items.Select(item => new OrderProduct
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.Price,
            }).ToList();

            _orderRepository.AddOrder(order);
            _shoppingCart.ClearCart(userId);

            return RedirectToAction("Index", "Order");
        }
    }
}

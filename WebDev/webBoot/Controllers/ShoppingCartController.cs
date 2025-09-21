using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace WebDev.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IOrderRepository _orderRepository;

        public ShoppingCartController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        

    }
}

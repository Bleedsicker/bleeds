using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using WebDev.Configuration;
using WebDev.Dto;
using WebDev.Interfaces;

namespace WebDev.Controllers
{
    public class OrderController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IShoppingCartService _shoppingCartService;

        public OrderController(IApiService apiService, IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
            _apiService = apiService;
        }
        public async Task<IActionResult> Index()
        {
            var userId = _shoppingCartService.GetUserId();

            var response = await _apiService.GetAsync<List<OrderDto>>($"Order/GetOrders?userId={userId}");

            return View(response ?? new List<OrderDto>());
        }
        public async Task<IActionResult> Orders(long id)
        {
            var response = await _apiService.GetAsync<OrderDto>($"Order/GetOrder?id={id}");

            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> AddOrder()
        {
            var userId = _shoppingCartService.GetUserId();
            var cart = await _shoppingCartService.GetCart(userId);

            if (cart == null || cart.Items == null || !cart.Items.Any())
                return RedirectToAction("Index", "ShoppingCart");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostOrder()
        {
            var userId = _shoppingCartService.GetUserId();
            
            var response = _apiService.PostAsync($"Order/PostOrder?userId={userId}", userId);

            await _shoppingCartService.ClearCart(userId);

            return RedirectToAction("Index", "Order");
        }

        
    }
}

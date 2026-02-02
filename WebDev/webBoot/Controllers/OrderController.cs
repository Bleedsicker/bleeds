using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using WebDev.Configuration;
using WebDev.Dto;
using WebDev.Services;

namespace WebDev.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApiSettings _apiSettings;
        private readonly IShoppingCartService _shoppingCartService;

        public OrderController(ApiSettings apiSettings, IShoppingCartService shoppingCartService)
        {
            _apiSettings = apiSettings;
            _shoppingCartService = shoppingCartService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _shoppingCartService.GetUserId();

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{_apiSettings.BaseUrl}/Order/GetOrders?userId={userId}");

            if (!response.IsSuccessStatusCode)
            {
                return View(new List<OrderDto>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var orders = JsonSerializer.Deserialize<List<OrderDto>>(json, JsonOptions());

            return View(orders ?? new List<OrderDto>());
        }

        public async Task<IActionResult> Orders(long id)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{_apiSettings.BaseUrl}/Order/GetOrder?id={id}");

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var json = await response.Content.ReadAsStringAsync();
            var order = JsonSerializer.Deserialize<OrderDto>(json, JsonOptions());

            return View(order);
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

            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync($"{_apiSettings.BaseUrl}/Order/PostOrder?userId={userId}",
                new StringContent("{}", Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ShoppingCart");
            }

            await _shoppingCartService.ClearCart(userId);

            return RedirectToAction("Index", "Order");
        }

        private static JsonSerializerOptions JsonOptions() => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }
}

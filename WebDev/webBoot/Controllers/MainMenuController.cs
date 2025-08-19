using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using WebDev.Models;

namespace WebDev.Controllers
{
    public class MainMenuController : Controller
    {
        private IProductRepository _productRepository;

        public MainMenuController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult MainMenu()
        {
            var products = _productRepository.GetProducts();
            var result = new List<ProductModel>();
            foreach (var product in products)
            {
                result.Add(new ProductModel
                {
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductId = product.Id
                });
            }

            var mainMenuModel = new MainMenuModel
            {
                Products = result
            };

            return View(mainMenuModel);
        }

        public IActionResult ProductMenu()
        {
            return View("~/Views/ProductMenu/AddProduct.cshtml");
        }


    }
}

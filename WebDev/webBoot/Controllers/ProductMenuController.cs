using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using WebDev.Models;
using Domain;


namespace WebDev.Controllers;

public class ProductMenuController : Controller
{

    private IProductRepository _productRepository;

    public ProductMenuController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public IActionResult AddProduct()
    {
        return View();
    }


    [HttpPost]
    public IActionResult AddProduct(ProductModel model)
    {
        _productRepository.AddProduct(new Product
        {
            ProductName = model.ProductName,
            ProductDescription = model.ProductDescription,
        });

        return RedirectToAction("MainMenu", "MainMenu");
    }

    [HttpGet]
    public IActionResult EditProduct(long id)
    {
        var product = _productRepository.GetProduct(id);
        var productModel = new ProductModel
        {
            ProductName = product.ProductName,
            ProductDescription = product.ProductDescription,
            ProductId = product.Id
        };
        return View(productModel);
    }

    [HttpPost]
    public IActionResult EditProduct(ProductModel model)
    {
        var product = _productRepository.GetProduct(model.ProductId.Value);
        product.ProductName = model.ProductName;
        product.ProductDescription = model.ProductDescription;
        _productRepository.UpdateProduct(product);

        return RedirectToAction("MainMenu", "MainMenu");
    }
}

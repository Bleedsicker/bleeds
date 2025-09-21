using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using WebDev.Models;
using Domain;


namespace WebDev.Controllers;

public class ProductController : Controller
{
    private IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
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
            Name = model.ProductName,
            Description = model.ProductDescription,
            Price = model.Price
        });

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult EditProduct(long id)
    {
        var product = _productRepository.GetProduct(id);
        var productModel = new ProductModel
        {
            ProductName = product.Name,
            ProductDescription = product.Description,
            Price = product.Price,
            ProductId = product.Id
        };
        return View(productModel);
    }

    [HttpPost]
    public IActionResult EditProduct(ProductModel model)
    {
        var product = _productRepository.GetProduct(model.ProductId.Value);
        product.Name = model.ProductName;
        product.Description = model.ProductDescription;
        product.Price = model.Price;
        _productRepository.UpdateProduct(product);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Index()
    {
        var products = _productRepository.GetProducts();
        var result = new List<ProductModel>();
        foreach (var product in products)
        {
            result.Add(new ProductModel
            {
                ProductName = product.Name,
                ProductDescription = product.Description,
                Price = product.Price,
                ProductId = product.Id
            });
        }

        return View(result);
    }
    public IActionResult DeleteProduct(long id)
    {
        _productRepository.DeleteProduct(id);

        return RedirectToAction(nameof(Index));
    }

}

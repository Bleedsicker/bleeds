using Microsoft.AspNetCore.Mvc;
using WebDev.Dto;
using WebDev.Interfaces;
using WebDev.Models;


namespace WebDev.Controllers;

public class ProductController : Controller
{
    private readonly IApiService _apiService;
    public ProductController(IApiService apiService)
    {
        _apiService = apiService;
    }

    [HttpGet]
    public IActionResult AddProduct()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductModel model)
    {
        var productDto = new ProductDto
        {
            Name = model.ProductName,
            Description = model.ProductDescription,
            Price = model.Price,
            Id = model.ProductId,
        };

        var response = await _apiService.PostAsync("Product/AddProduct", productDto);

        if (!response.IsSuccessStatusCode)
        {
            ModelState.AddModelError("", "registration is failed");
            return View(model);
        }
        else
        {
            return RedirectToAction(nameof(Index));
        }
    }

    [HttpGet]
    public IActionResult EditProduct(ProductDto productDto)
    {

        var productModel = new ProductModel
        {
            ProductName = productDto.Name,
            ProductDescription = productDto.Description,
            Price = productDto.Price,
            ProductId = productDto.Id
        };
        return View(productModel);
    }

    [HttpPost]
    public async Task<IActionResult> EditProduct(ProductModel model)
    {
        var productDto = new ProductDto
        {
            Name = model.ProductName,
            Price = model.Price,
            Id = model.ProductId,
            Description = model.ProductDescription,
        };

        var response = await _apiService.PostAsync("Product/EditProduct", productDto);

        if (!response.IsSuccessStatusCode)
        {
            ModelState.AddModelError("", "Edit is failed");
            return View(model);
        }
        else
        {
            return RedirectToAction(nameof(Index));
        }
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var response = await _apiService.GetAsync<List<ProductDto>>("Product/GetProducts");
        //var response = await new HttpClient().GetAsync($"{_apiSettings.BaseUrl}/Product/GetProducts");
        //if (!response.IsSuccessStatusCode)
        //{
        //    return View(new List<ProductModel>());
        //}
        //var json = await response.Content.ReadAsStringAsync();

        //var productsDto = JsonSerializer.Deserialize<List<ProductDto>>(response, JsonOptions());
        var result = response.Select(o => new ProductModel
        {
            ProductId = o.Id,
            Price = o.Price,
            ProductDescription = o.Description,
            ProductName = o.Name,
        }).ToList();

        return View(result);
    }

    public async Task<IActionResult> DeleteProduct(long id)
    {
        await _apiService.DeleteAsync($"Product/DeleteProduct/{id}");
        return RedirectToAction(nameof(Index));
    }
}

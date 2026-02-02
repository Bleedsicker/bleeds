using DataAccess.Repository;
using Domain;
using Microsoft.AspNetCore.Mvc;
using WebDevAPI.Dto;

namespace WebDevAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    [Route("GetProducts")]
    public IActionResult GetProducts()
    {
        return Ok(_productRepository.GetProducts());
    }

    [HttpGet]
    [Route("GetProduct/{productId}/{userId}")]
    public IActionResult GetProduct(long productId, string userId)
    {
        var product = _productRepository.GetProduct(productId);

        //var showProduct = product.(); //TODO

        return Ok(product);
    }

    [HttpPost]
    [Route("AddProduct")]
    public IActionResult AddProduct([FromBody] ProductDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Description = productDto.Description,
            Price = productDto.Price,
            Id = productDto.Id,
        };

        _productRepository.AddProduct(product);

        var result = new ProductDto
        {
            Name = productDto.Name,
            Price = productDto.Price,
            Id = productDto.Id,
        };
        return Ok(result);
    }

    [HttpPost]
    [Route("EditProduct")]
    public IActionResult EdtiProduct([FromBody] ProductDto productDto)
    {
        var product = _productRepository.GetProduct(productDto.Id);
        product.Id = productDto.Id;
        product.Name = productDto.Name;
        product.Price = productDto.Price;
        product.Description = productDto.Description;
        _productRepository.UpdateProduct(product);
        return Ok(product);
    }

    [HttpDelete]
    [Route("DeleteProduct/{id}")]
    public IActionResult DeleteProduct(long id)
    {
        _productRepository.DeleteProduct(id);
        return Ok();
    }
}


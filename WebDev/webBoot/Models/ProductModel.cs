using System.ComponentModel.DataAnnotations;

namespace WebDev.Models;

public class ProductModel
{
    [Required(ErrorMessage = "Name is empty")]
    public string ProductName { get; set; }

    [Required(ErrorMessage = "Description is empty")]
    public string ProductDescription { get; set; }

    [Required(ErrorMessage = "Price is empty")]
    public decimal Price { get; set; }    

    public long? ProductId { get; set; }
}

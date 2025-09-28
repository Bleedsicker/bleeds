namespace WebDev.Models;

public class ShoppingCartItemModel
{
    public long ProductId { get; set; }

    public string ProductName { get; set; }

    public string ProductDescription { get; set; }

    public decimal Price { get; set; }

    public long Quantity { get; set; }
}

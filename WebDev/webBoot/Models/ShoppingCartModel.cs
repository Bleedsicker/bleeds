namespace WebDev.Models;

public class ShoppingCartModel
{
    public long UserId { get; set; }

    public List<ShoppingCartItemModel> Items { get; set; } = new List<ShoppingCartItemModel>();



}

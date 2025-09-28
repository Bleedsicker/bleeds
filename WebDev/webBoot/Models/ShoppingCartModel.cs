namespace WebDev.Models;

public class ShoppingCartModel
{
    public string UserId { get; set; }

    public List<ShoppingCartItemModel> Items { get; set; } = new List<ShoppingCartItemModel>();




}

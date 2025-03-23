
namespace OnlineShop;

public class ProductService
{
    public static Product CreateNewProduct()
    {
        var product = new Product();
        Console.WriteLine("Enter the product name:");
        product.ProductName = Console.ReadLine();
        Console.WriteLine("Enter the product descrtiprion:");
        product.ProductDescription = Console.ReadLine();
        
        return product;
    }

    public static void ChangeProduct(Product product)
    {
        Console.WriteLine("Enter the new product name:");
        product.ProductName = Console.ReadLine();
        Console.WriteLine("Enter the new product description:");
        product.ProductDescription = Console.ReadLine();
    }

}

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

    public static void ShowProductList(List<Product> products)
    {
        for (int i = 0; i < products.Count; i++)
        {
            var product = products[i];
            Console.WriteLine(i + 1 + ". " + product.ProductName);
        }
    }
}

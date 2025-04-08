namespace OnlineShop.Services;

public class ProductService
{
    public void ProductMenu(Shop productMenu)
    {
        while (true)
        {
            ShowProductMenu();
            var productMenuChoiceT = Console.ReadLine();
            var productMenuChoice = int.Parse(productMenuChoiceT);
            if (productMenuChoice == 5)
            {
                break;
            }
            else if (productMenuChoice == 1)
            {
                var productService = CreateNewProduct();
                productMenu.Products.Add(productService);
            }
            else if (productMenuChoice == 2)
            {
                ShowProductList(productMenu.Products);
                Console.WriteLine("Enter the product number:");
                var numberOfProductT = Console.ReadLine();
                var numberOfProduct = 0;
                if (int.TryParse(numberOfProductT, out numberOfProduct) &&
                    productMenu.Products.Count > numberOfProduct - 1 &&
                    numberOfProduct > 0)
                {
                    productMenu.Products.RemoveAt(numberOfProduct - 1);
                }
            }
            else if (productMenuChoice == 3)
            {
                ShowProductList(productMenu.Products);
                Console.WriteLine("Press any key to return");
                Console.ReadKey();
            }
            else if (productMenuChoice == 4)
            {
                ShowProductList(productMenu.Products);
                Console.WriteLine("Enter the product number:");
                var numberOfProductT = Console.ReadLine();
                var numberOfProduct = 0;
                if (int.TryParse(numberOfProductT, out numberOfProduct) &&
                    productMenu.Products.Count > numberOfProduct - 1 &&
                    numberOfProduct > 0)
                {
                    var product = productMenu.Products.ElementAt(numberOfProduct - 1);
                    ChangeProduct(product);
                }
            }
        }
    }
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
    private void ShowProductMenu()
    {
        Console.WriteLine("1. Add product");
        Console.WriteLine("2. Delete product");
        Console.WriteLine("3. Show purchase list");
        Console.WriteLine("4. Change product");
        Console.WriteLine("5. Return to the main menu");
    }
}

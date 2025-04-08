namespace OnlineShop.Services;

public class ShoppingCartService
{
    public void ShoppingCartMenu(Shop cartMenu, ShoppingCart shoppingCart)
    {
        while (true)
        {
            ShowPurchaseMenu();
            var PurchaseMenuChoiceT = Console.ReadLine();
            var PurchaseMenuChoice = int.Parse(PurchaseMenuChoiceT);
            if (PurchaseMenuChoice == 5)
            {
                break;
            }
            else if (PurchaseMenuChoice == 1)
            {
                shoppingCart.AddToCart(cartMenu.Products);
            }
            else if (PurchaseMenuChoice == 2)
            {
                shoppingCart.ShowCartList(shoppingCart.ProductsCart);
                Console.WriteLine("Press any key to go back");
                Console.ReadKey();
            }
            else if (PurchaseMenuChoice == 3)
            {
                shoppingCart.ShowCartList(shoppingCart.ProductsCart);
                Console.WriteLine("Choose product you want to delete");
                var numberOfProductT = Console.ReadLine();
                var numberOfProduct = 0;
                if (int.TryParse(numberOfProductT, out numberOfProduct) &&
                    cartMenu.Products.Count > numberOfProduct - 1 &&
                    numberOfProduct > 0)
                {
                    shoppingCart.ProductsCart.RemoveAt(numberOfProduct - 1);
                }

            }
        }
    }
    private void ShowPurchaseMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Add items to cart");
        Console.WriteLine("2. View cart");
        Console.WriteLine("3. Delete items from cart");
        Console.WriteLine("4. Apply discount code");
        Console.WriteLine("5. Return to the main menu");
    }
}

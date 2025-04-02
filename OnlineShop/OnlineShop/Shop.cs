
namespace OnlineShop;

public class Shop
{
    public List<User> Users { get; set; }
    public List<Product> Products { get; set; }
    public List<Coupons> Coupons { get; set; }

    public int Choice()
    {
        Console.WriteLine("1. register.\t2. login");
        var ChoiceText = Console.ReadLine();
        var Choice = int.Parse(ChoiceText);
        return Choice;
    }

    public User? NewUser()
    {
        var newUser = new User();

        Console.WriteLine("userName:");
        newUser.UserName = Console.ReadLine();
        for (int i = 0; i < Users.Count; i++)
        {
            var user = Users[i];
            if (user.UserName == newUser.UserName)
            {
                Console.WriteLine("User is used");
                return null;
            }
        }

        while (true)
        {
            Console.WriteLine("Password:");
            newUser.Password = Console.ReadLine();
            Console.WriteLine("Wrire the password again");
            var verification = Console.ReadLine();
            if (verification == newUser.Password)
            {
                break;
            }
            else
            {
                Console.WriteLine("Password is wrong");
            }
        }

        return newUser;
    }

    public User? Login()
    {
        Console.WriteLine("Enter the username;");
        var userName = Console.ReadLine();
        Console.WriteLine("Enter the password");
        var userPassword = Console.ReadLine();
        for (int i = 0; i < Users.Count; i++)
        {
            var user = Users[i];

            if (user.Password == userPassword && user.UserName == userName)
            {
                return user;
            }
        }
        Console.WriteLine("User with this username and password can't be found");
        return null;
    }

    public int MainMenuChoice(User registeredUser)
    {
        ShowMainMenu(registeredUser);

        var choiceText = Console.ReadLine();
        var choice = int.Parse(choiceText);
        return choice;
    }


    public void ProcessMainMenuChoice(User registeredUser, int choice, ShoppingCart shoppingCart)
    {
        if (choice == 1)
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
                    var productService = ProductService.CreateNewProduct();
                    Products.Add(productService);
                }
                else if (productMenuChoice == 2)
                {
                    ProductService.ShowProductList(Products);
                    Console.WriteLine("Enter the product number:");
                    var numberOfProductT = Console.ReadLine();
                    var numberOfProduct = 0;
                    if (int.TryParse(numberOfProductT, out numberOfProduct) &&
                        Products.Count > numberOfProduct - 1 &&
                        numberOfProduct > 0)
                    {
                        Products.RemoveAt(numberOfProduct - 1);
                    }
                }
                else if (productMenuChoice == 3)
                {
                    // ShowPurchaseList();
                    // создать заказ. он будет содержать юзера и список продуктов.
                }
                else if (productMenuChoice == 4)
                {
                    ProductService.ShowProductList(Products);
                    Console.WriteLine("Enter the product number:");
                    var numberOfProductT = Console.ReadLine();
                    var numberOfProduct = 0;
                    if (int.TryParse(numberOfProductT, out numberOfProduct) &&
                        Products.Count > numberOfProduct - 1 &&
                        numberOfProduct > 0)
                    {
                        var product = Products.ElementAt(numberOfProduct - 1);
                        ProductService.ChangeProduct(product);
                    }
                }
            }
        }
        if (choice == 2)
        {
            while (true)
            {
                ShowCouponsMenu();
                var couponsMenuChoiceT = Console.ReadLine();
                var couponsMenuChoice = int.Parse(couponsMenuChoiceT);
                if (couponsMenuChoice == 4)
                {
                    break;
                }
                else if (couponsMenuChoice == 1)
                {
                    var couponService = CouponService.CreateNewCoupon();
                    Coupons.Add(couponService);
                }
                else if(couponsMenuChoice == 2)
                {
                    CouponService.ShowAvailableCoupons(Coupons);
                    Console.WriteLine("Press any key to go back");
                    Console.ReadLine();
                }
                else if(couponsMenuChoice == 3)
                {
                    CouponService.ShowAvailableCoupons(Coupons);
                    Console.WriteLine("Choose coupons you want to delete");
                    var numberOfCouponT = Console.ReadLine();
                    var numberOfCoupon = 0;
                    if (int.TryParse(numberOfCouponT, out numberOfCoupon) &&
                        Coupons.Count > numberOfCoupon - 1 &&
                        numberOfCoupon > 0)
                    {
                        Coupons.RemoveAt(numberOfCoupon - 1);
                    }
                }
            }
        }
        if (choice == 3)
        {
            while (true)
            {
                ShowPurchaseHistoryMenu();
                var returnToMenuT = Console.ReadLine();
                var returnToMenu = int.Parse(returnToMenuT);
                if (returnToMenu == 3)
                {
                    break;
                }
            }
        }
        if (choice == 4)
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
                    shoppingCart.AddToCart(Products);

                }
                else if (PurchaseMenuChoice == 2)
                {
                    shoppingCart.ShowCartList(shoppingCart.ProductsCart);
                    Console.WriteLine("Press any key to go back");
                    Console.ReadLine();
                }
                else if (PurchaseMenuChoice == 3)
                {
                    shoppingCart.ShowCartList(shoppingCart.ProductsCart);
                    Console.WriteLine("Choose product you want to delete");
                    var numberOfProductT = Console.ReadLine();
                    var numberOfProduct = 0;
                    if (int.TryParse(numberOfProductT, out numberOfProduct) &&
                        Products.Count > numberOfProduct - 1 &&
                        numberOfProduct > 0)
                    {
                        shoppingCart.ProductsCart.RemoveAt(numberOfProduct - 1);
                    }

                }
            }
        }
        if (choice == 5)
        {
            ShowUserSettingsMenu();
            UserSettings.ChangeUsername(registeredUser);
        }
        if (choice == 6)
        {
            ShowChangePasswordMenu();
            UserSettings.ChangePassword(registeredUser);
        }
    }



    private void ShowMainMenu(User user)
    {
        Console.WriteLine("Welcome " + user.UserName);
        Console.WriteLine("1. Products");
        Console.WriteLine("2. Coupons");
        Console.WriteLine("3. Purchase history");
        Console.WriteLine("4. Purchase");
        Console.WriteLine("5. Change user settings");
        Console.WriteLine("6. Change password");
        Console.WriteLine("7. Logout");
    }

    private void ShowProductMenu()
    {
        Console.WriteLine("1. Add product");
        Console.WriteLine("2. Delete product");
        Console.WriteLine("3. Show purchase list");
        Console.WriteLine("4. Change product");
        Console.WriteLine("5. Return to the main menu");
    }

    private void ShowCouponsMenu()
    {
        //Купоны такие же как продукты
        Console.Clear();
        Console.WriteLine("1. Add coupon");
        Console.WriteLine("2. View available coupons");
        Console.WriteLine("3. Remove a coupon");
        Console.WriteLine("4. Return to the main menu");
    }

    private void ShowPurchaseHistoryMenu()
    {
        Console.Clear();
        Console.WriteLine("1. View all past purchases");
        Console.WriteLine("2. Request a return or refund");
        Console.WriteLine("3. Return to the main menu");
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

    private void ShowUserSettingsMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Update personal information");
        Console.WriteLine("2. Change email address");
        Console.WriteLine("3. Change the shipping address");
        Console.WriteLine("4. Return to the main menu");
    }

    private void ShowChangePasswordMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Change password");
        Console.WriteLine("2. Return to the main menu");
    }

}








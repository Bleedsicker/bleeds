
using OnlineShop.Services;

namespace OnlineShop;

public class Shop
{
    public List<User> Users { get; set; }
    public List<Product> Products { get; set; }
    public List<Coupon> Coupons { get; set; }

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
    public void ProcessMainMenuChoice(User registeredUser, int choice, ShoppingCart shoppingCart, ProductService product, Shop mainMenu, CouponService coupon, ShoppingCartService shoppingCartService)
    {
        if (choice == 1)
        {
            product.ProductMenu(mainMenu);
        }
        else if (choice == 2)
        {
            coupon.CouponMenu(mainMenu);
        }
        else if (choice == 3)
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
        else if (choice == 4)
        {
            shoppingCartService.ShoppingCartMenu(mainMenu, shoppingCart);
        }
        else if (choice == 5)
        {
            ShowUserSettingsMenu();
            UserService.ChangeUsername(registeredUser);
        }
        else if (choice == 6)
        {
            ShowChangePasswordMenu();
            UserService.ChangePassword(registeredUser);
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
    private void ShowPurchaseHistoryMenu()
    {
        Console.Clear();
        Console.WriteLine("1. View all past purchases");
        Console.WriteLine("2. Request a return or refund");
        Console.WriteLine("3. Return to the main menu");
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








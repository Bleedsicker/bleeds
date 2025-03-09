

namespace OnlineShop;

public class Shop
{
    public List<User> Users { get; set; }
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

    public void Menu(User registeredUser)
    {
        var user = new User();
        var menu = new Shop();
        for (int i = 0; i < Users.Count; i++)
        {
            user = Users[i];
            if (user.UserName == registeredUser.UserName)
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
        }

        var logout_text = Console.ReadLine();
        var logout = int.Parse(logout_text);
        if (logout == 7)
        {
            menu.Choice();
        }
    }
}








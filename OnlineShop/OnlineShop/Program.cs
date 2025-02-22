namespace OnlineShop;

public class Shop
{
    public string User;
    public string Password;

    public void NewUser()
    {
        Console.WriteLine("1. register.\t2. login");
        var loginText = Console.ReadLine();
        var login = int.Parse(loginText);
        string UserName;
        string passwordUser;
        if (login == 1)
        {
            Console.WriteLine("Register new user");
            Console.WriteLine("Enter the user name");
            UserName = Console.ReadLine();
            Console.WriteLine("Enter the password");
            passwordUser = Console.ReadLine();
        }
    }
}


namespace OnlineShop;

public class UserSettings
{
    public static void ChangeUsername(User registeredUser)
    {
        while (true)
        {
            var returnToMenuT = Console.ReadLine();
            var returnToMenu = int.Parse(returnToMenuT);
            if (returnToMenu == 1)
            {
                Console.WriteLine("Enter the new username:");
                registeredUser.UserName = Console.ReadLine();
            }
            else if (returnToMenu == 4)
            {
                break;
            }
        }
    }

    public static void ChangePassword(User registeredUser)
    {
        while (true)
        {
            var userList = new Shop();
            
            var returnToMenuT = Console.ReadLine();
            var returnToMenu = int.Parse(returnToMenuT);
            if (returnToMenu == 1)
            {
                Console.WriteLine("Enter the current password");
                var userPassword = Console.ReadLine();
                for (int i = 0; i < userList.Users.Count; i++)
                {
                    var user = userList.Users[i];

                    if (user.Password == userPassword)
                    {
                        Console.WriteLine("Enter the new password");
                        registeredUser.Password = Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Password is wrong");
                    }
                }
            }
            else if (returnToMenu == 2)
            {
                break;
            }
        }
    }
}


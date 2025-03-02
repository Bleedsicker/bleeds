using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using OnlineShop;

namespace OnlineShop;

public class Shop
{
    public List<User> Users { get; set; }
    public int Choice()
    {
        Console.WriteLine("1. register.\t2. login");
        var loginText = Console.ReadLine();
        var login = int.Parse(loginText);
        return login;
    }

    public User NewUser()
    {
        var user = new User();
        if (Choice() == 1)
            {
                Console.WriteLine("userName:");
                user.UserName = Console.ReadLine();
                for (int i = 0; i < Users.Count; i++)
                {
                    var userr = Users[i];
                    if (userr.UserName == user.UserName)
                    {
                        Console.WriteLine("User is used");
                    return userr;
                    }
                }
                Console.WriteLine("Password:");
                user.Password = Console.ReadLine();
                Console.WriteLine("Address:");
                user.Address = Console.ReadLine();
                Console.WriteLine("Age:");
                user.Age = int.Parse(Console.ReadLine());
                Console.WriteLine("Email:");
                user.Email = Console.ReadLine();

            }
        return user;
    }

    public User OldUser()
    {
        var oldUserr = new User();
        if (Choice() == 2)
        {
            Console.WriteLine("Enter the username;");
            var oldUserName = Console.ReadLine();
            Console.WriteLine("Enter the password");
            var oldUserPassword = Console.ReadLine();
            for (int i = 0; i < Users.Count; i++)
            {
                var oldUser = Users[i];
                if (oldUser.UserName == oldUserName)
                {
                    if (oldUser.Password == oldUserPassword)
                    {
                        Console.WriteLine("Welcome.");
                        return oldUser;
                    }
                    else if (oldUser.UserName != oldUserName)
                    {
                        if (oldUser.Password != oldUserPassword)
                        {
                            Console.WriteLine("try again");
                        }
                    }
                }
            }
        }
        return oldUserr;
    }
}



        
       
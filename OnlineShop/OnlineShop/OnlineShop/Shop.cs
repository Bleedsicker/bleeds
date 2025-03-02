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
        var ChoiceText = Console.ReadLine();
        var Choice = int.Parse(ChoiceText);
        return Choice;
    }

    public User? NewUser()
    {
        var Newuser = new User();

        Console.WriteLine("userName:");
        Newuser.UserName = Console.ReadLine();
        for (int i = 0; i < Users.Count; i++)
        {
            var user = Users[i];
            if (user.UserName == Newuser.UserName)
            {
                Console.WriteLine("User is used");
                return null;
            }
        }
        Console.WriteLine("Password:");
        Newuser.Password = Console.ReadLine();

        return Newuser;
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
                Console.WriteLine("Welcome.");
                return user;
            }

        }
        Console.WriteLine("User with with username and password cant be found");
        return null;
    }



}






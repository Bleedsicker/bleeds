using OnlineShop;


var shop = new Shop();
shop.Users = new List<User>();

while (true)
{
    var userChoice = shop.Choice();
    if (userChoice == 1)
    {
        var newUser = shop.NewUser();
        if (newUser != null)
        {
            shop.Users.Add(newUser);
        }
    }
    else if (userChoice == 2)
    {
        var registeredUser = shop.Login();
        if (registeredUser != null)
        {
            shop.Menu(registeredUser);
        }
    }
}

using OnlineShop;


var shop = new Shop();
shop.Users = new List<User>();
var newUser = shop.NewUser();
shop.Users.Add(newUser);
shop.NewUser();
shop.Users.Add(newUser);
shop.OldUser();

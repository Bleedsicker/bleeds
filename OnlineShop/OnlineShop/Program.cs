using OnlineShop;
using OnlineShop.Services;

var cart = new ShoppingCart();
var shop = new Shop();
shop.Users = new List<User>();
shop.Products = new List<Product>();
shop.Coupons = new List<Coupon>();
cart.ProductsCart = new List<Product>();
var productService = new ProductService();
var couponService = new CouponService();
var shoppingCartService = new ShoppingCartService();

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
            while (registeredUser != null)
            {
                var mainMenuChoice = shop.MainMenuChoice(registeredUser);
                if (mainMenuChoice == 7)
                {
                    registeredUser = null;
                }
                else
                {
                    shop.ProcessMainMenuChoice(registeredUser, mainMenuChoice, cart, productService, shop, couponService, shoppingCartService);
                }
            }
        }
    }
}

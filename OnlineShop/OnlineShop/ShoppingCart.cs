
namespace OnlineShop
{
    public class ShoppingCart
    {

        public List<Product> ProductsCart { get; set; }
        //доделать пункты меню

        public void AddToCart(List<Product> products)
        {
            while (true)
            {

                ProductService.ShowProductList(products);
                Console.WriteLine("Choose your products: ");
                var numberOfProductT = Console.ReadLine();
                var numberOfProduct = 0;
                if (int.TryParse(numberOfProductT, out numberOfProduct) &&
                    products.Count > numberOfProduct - 1 &&
                    numberOfProduct > 0)
                {
                    ProductsCart.Add(products[numberOfProduct - 1]);
                    break;
                }
            }
        }

        public void ShowCartList(List<Product> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                var product = products[i];
                Console.WriteLine(i + 1 + ". " + product.ProductName);
            }
        }


    }
}

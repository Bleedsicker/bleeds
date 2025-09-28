using Domain;

namespace DataAccess.Repository;
public interface IProductRepository
{
    List<Product> GetProducts();
    void AddProduct(Product product);
    Product GetProduct(long id);
    void UpdateProduct(Product product);
    void DeleteProduct(long id);
}

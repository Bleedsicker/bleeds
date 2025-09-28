using Domain;

namespace DataAccess.Repository;
internal class ProductRepository : IProductRepository
{
    private readonly WebDevDBcontext _dbContext;

    public ProductRepository(WebDevDBcontext dBContext)
    {
        _dbContext = dBContext;
    }

    public void AddProduct(Product product)
    {
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
    }

    public List<Product> GetProducts()
    {
        return _dbContext.Products.ToList();
    }

    public Product GetProduct(long id)
    {
        return _dbContext.Products.FirstOrDefault(o => o.Id == id);
    }

    public void UpdateProduct(Product product)
    {
        _dbContext.Products.Update(product);
        _dbContext.SaveChanges();
    }

    public void DeleteProduct(long id)
    {
        var product = _dbContext.Products.FirstOrDefault(o => o.Id == id);
        _dbContext.Remove(product);
        _dbContext.SaveChanges();
    }
}

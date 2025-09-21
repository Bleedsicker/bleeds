namespace DataAccess.Repository;
using Domain;

internal class OrderRepository: IOrderRepository
{
    private readonly WebDevDBcontext _dbContext;
    public OrderRepository(WebDevDBcontext dBContext)
    {
        _dbContext = dBContext;
    }
    public void AddOrder(Order order)
    {
        _dbContext.Orders.Add(order);
        _dbContext.SaveChanges();
    }

    public List<Order> GetOrders()
    {
        return _dbContext.Orders.ToList();
    }
}

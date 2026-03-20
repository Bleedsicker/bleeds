using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;
public class OrderRepository: IOrderRepository
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

    public List<Order> GetOrders(long userId)
    {
        return _dbContext.Orders
            .Where(o => o.UserId == userId)
            .Include(op => op.OrderProducts)
            .ToList();
    }

    public Order GetOrder(long id)
    {
        return _dbContext.Orders
            .Include(o => o.OrderProducts)
            .FirstOrDefault(o => o.OrderId == id);
    }
}

using Domain;

namespace DataAccess.Repository;
public interface IOrderRepository
{
    List<Order> GetOrders();
    void AddOrder(Order order);
}

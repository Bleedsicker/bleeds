using Domain;

namespace DataAccess.Repository;
public interface IOrderRepository
{
    List<Order> GetOrders(long id);
    void AddOrder(Order order);

    Order GetOrder(long userId);
}



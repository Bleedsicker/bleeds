using Domain;

namespace DataAccess.Repository;
public interface IOrderRepository
{
    List<Order> GetOrders(long userId);
    void AddOrder(Order order);

    Order GetOrder(long orderId);
}



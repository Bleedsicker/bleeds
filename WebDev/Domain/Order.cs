namespace Domain;

public class Order
{
    public long OrderId { get; set; }

    public DateTimeOffset OrderDate { get; set; }

    public long UserId { get; set; }

    public User User { get; set; }

    public ICollection<OrderProduct> OrderProducts { get; set; }
}

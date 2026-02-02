using Domain;

namespace WebDevAPI.Dto;

public class OrderDto
{
    public long OrderId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public long UserId { get; set; }
    public ICollection<OrderProductDto> OrderProducts { get; set; } = new List<OrderProductDto>();
}

using Domain;

namespace WebDevAPI.Dto;

public class OrderProductDto
{
    public decimal UnitPrice { get; set; }

    public long ProductId { get; set; }

    public long Quantity { get; set; }
}

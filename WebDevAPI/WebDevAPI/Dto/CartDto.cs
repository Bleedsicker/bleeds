namespace WebDevAPI.Dto;

public class CartDto
{
    public long UserId { get; set; }
    public List<CartItemDto> Items { get; set; } = new List<CartItemDto>();
}

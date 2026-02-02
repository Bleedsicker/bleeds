using System.ComponentModel.DataAnnotations;

namespace WebDev.Models;

public class CouponModel
{
    [Required(ErrorMessage = "Name is empty")]
    public string CouponName { get; set; }

    [Required(ErrorMessage = "Discount is empty")]
    public decimal CouponDiscount { get; set; }

    [Required(ErrorMessage = "Id is empty")]
    public string CouponId { get; set; }

    public long Id { get; set; }
}


namespace OnlineShop
{
    public class Coupon
    {
        public string CouponName { get; set; }

        public string CouponId { get; set; }

        public DiscountType Discount {  get; set; }

        public double DiscountAmount { get; set; }
        
    }
}

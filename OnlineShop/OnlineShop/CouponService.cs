
namespace OnlineShop
{
    public class CouponService
    {
        public static Coupons CreateNewCoupon()
        {
            var coupon = new Coupons();
            Console.WriteLine("Enter the coupon name: ");
            coupon.CouponName = Console.ReadLine();
            Console.WriteLine("Enter the coupon ID: ");
            coupon.CouponId = Console.ReadLine();
            Console.WriteLine("Enter the type of coupon ( Prosent or Absolut)");
            string discountType = Console.ReadLine();
            DiscountType selectedDiscountType;
            if (Enum.TryParse(discountType, true, out selectedDiscountType))
            {
                coupon.Discount = selectedDiscountType;
                if (selectedDiscountType == DiscountType.Prosent)
                {
                    Console.WriteLine("Enter the percent of coupon");
                    if (double.TryParse(Console.ReadLine(), out double percentage))
                    {
                        coupon.DiscountAmount = percentage;
                    }
                }
                else if (selectedDiscountType == DiscountType.Absolut)
                {
                    Console.WriteLine("Enter the value");
                    if (int.TryParse(Console.ReadLine(), out int value))
                    {
                        coupon.DiscountAmount = value;
                    }
                }
            }
            else
            {
                Console.WriteLine("Try again");
            }


            return coupon;
        }

        public static void ShowAvailableCoupons(List<Coupons> coupons)
        {
            for (int i = 0; i < coupons.Count; i++)
            {
                Console.WriteLine(i + 1 + "." + coupons[i].CouponName);
            }
        }

    }
}

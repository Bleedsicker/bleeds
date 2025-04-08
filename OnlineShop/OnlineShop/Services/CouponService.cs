namespace OnlineShop.Services;

public class CouponService
{
    public static Coupon CreateNewCoupon()
    {
        var coupon = new Coupon();
        Console.WriteLine("Enter the coupon name: ");
        coupon.CouponName = Console.ReadLine();
        Console.WriteLine("Enter the coupon ID: ");
        coupon.CouponId = Console.ReadLine();
        Console.WriteLine("Enter the type of coupon ( Percent or Absolut)");
        string discountType = Console.ReadLine();
        DiscountType selectedDiscountType;

        if (Enum.TryParse(discountType, true, out selectedDiscountType))
        {
            coupon.Discount = selectedDiscountType;
            Console.WriteLine("Enter the value");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                coupon.DiscountAmount = value;
            }
        }
        else
        {
            Console.WriteLine("Try again");
        }
        return coupon;
    }
    public static void ChangeCoupon(Coupon coupon)
    {
        Console.WriteLine("Enter the new coupon name: ");
        coupon.CouponName = Console.ReadLine();
        Console.WriteLine("Enter the new coupon ID: ");
        coupon.CouponId = Console.ReadLine();
        Console.WriteLine("Enter the new type of coupon ( Percent or Absolut)");
        string discountType = Console.ReadLine();
        DiscountType selectedDiscountType;

        if (Enum.TryParse(discountType, true, out selectedDiscountType))
        {
            coupon.Discount = selectedDiscountType;
            Console.WriteLine("Enter the value");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                coupon.DiscountAmount = value;
            }
        }
        else
        {
            Console.WriteLine("Try again");
        }
    }
    public static void ShowAvailableCoupons(List<Coupon> coupons)
    {
        for (int i = 0; i < coupons.Count; i++)
        {
            Console.WriteLine(i + 1 + "." + coupons[i].CouponName);
        }
    }
    public void CouponMenu(Shop couponMenu)
    {
        while (true)
        {
            ShowCouponsMenu();
            var couponsMenuChoiceT = Console.ReadLine();
            var couponsMenuChoice = int.Parse(couponsMenuChoiceT);
            if (couponsMenuChoice == 5)
            {
                break;
            }
            else if (couponsMenuChoice == 1)
            {
                var couponService = CreateNewCoupon();
                couponMenu.Coupons.Add(couponService);
            }
            else if (couponsMenuChoice == 2)
            {
                ShowAvailableCoupons(couponMenu.Coupons);
                Console.WriteLine("Press any key to go back");
                Console.ReadLine();
            }
            else if (couponsMenuChoice == 3)
            {
                ShowAvailableCoupons(couponMenu.Coupons);
                Console.WriteLine("Choose coupons you want to delete");
                var numberOfCouponT = Console.ReadLine();
                var numberOfCoupon = 0;
                if (int.TryParse(numberOfCouponT, out numberOfCoupon) &&
                    couponMenu.Coupons.Count > numberOfCoupon - 1 &&
                    numberOfCoupon > 0)
                {
                    couponMenu.Coupons.RemoveAt(numberOfCoupon - 1);
                }
            }
            else if(couponsMenuChoice == 4)
            {
                ShowAvailableCoupons(couponMenu.Coupons);
                Console.WriteLine("Enter the coupon number: ");
                var numberOfCouponT = Console.ReadLine();
                var numberOfCoupon = 0;
                if (int.TryParse(numberOfCouponT, out numberOfCoupon) &&
                    couponMenu.Coupons.Count > numberOfCoupon - 1 &&
                    numberOfCoupon > 0)
                {
                    var coupon = couponMenu.Coupons.ElementAt(numberOfCoupon - 1);
                    ChangeCoupon(coupon);
                }
            }
        }
    }
    private void ShowCouponsMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Add coupon");
        Console.WriteLine("2. View available coupons");
        Console.WriteLine("3. Remove a coupon");
        Console.WriteLine("4. Change coupon");
        Console.WriteLine("5. Return to the main menu");
    }
}

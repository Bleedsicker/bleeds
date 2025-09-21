using Domain;

namespace DataAccess.Repository;

public interface ICouponRepository
{
    List<Coupon> GetCoupons();

    void AddCoupon(Coupon coupon);
    Coupon GetCoupon(long id);
    void UpdateCoupon(Coupon coupon);
    void DeleteCoupon(long id);
}

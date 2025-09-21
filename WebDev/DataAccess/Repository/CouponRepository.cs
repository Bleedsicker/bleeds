using Domain;

namespace DataAccess.Repository;

internal class CouponRepository : ICouponRepository
{
    private readonly WebDevDBcontext _dbContext;

    public CouponRepository(WebDevDBcontext dBContext)
    {
        _dbContext = dBContext;
    }

    public void AddCoupon(Coupon coupon)
    {
        _dbContext.Coupons.Add(coupon);
        _dbContext.SaveChanges();
    }

    public List<Coupon> GetCoupons()
    {
        return _dbContext.Coupons.ToList();
    }

    public Coupon GetCoupon(long id)
    {
        return _dbContext.Coupons.FirstOrDefault(o => o.Id == id);
    }

    public void UpdateCoupon(Coupon coupon)
    {
        _dbContext.Coupons.Update(coupon);
        _dbContext.SaveChanges();
    }

    public void DeleteCoupon(long id)
    {
        var coupon = _dbContext.Coupons.FirstOrDefault(o => o.Id == id);
        _dbContext.Remove(coupon);
        _dbContext.SaveChanges();
    }
}

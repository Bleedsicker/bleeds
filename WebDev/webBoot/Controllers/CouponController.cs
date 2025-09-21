using DataAccess.Repository;
using Domain;
using Microsoft.AspNetCore.Mvc;
using WebDev.Models;

namespace WebDev.Controllers;
public class CouponController : Controller
{
    private ICouponRepository _couponRepository;

    public CouponController(ICouponRepository couponRepository)
    {
        _couponRepository = couponRepository;
    }

    public IActionResult Index()
    {
        var coupons = _couponRepository.GetCoupons();
        var result = new List<CouponModel>();
        foreach (var coupon in coupons)
        {
            result.Add(new CouponModel
            {
                CouponName = coupon.CouponName,
                CouponId = coupon.CouponId,
                Id = coupon.Id,
                CouponDiscount = coupon.CouponDiscount
            });
        }

        return View(result);
    }

    [HttpGet]
    public IActionResult AddCoupon()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddCoupon(CouponModel model)
    {
        _couponRepository.AddCoupon(new Coupon
        {
            CouponName = model.CouponName,
            CouponId = model.CouponId,
            CouponDiscount= model.CouponDiscount,
        });

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult EditCoupon(long id)
    {
        var coupon = _couponRepository.GetCoupon(id);
        var couponModel = new CouponModel
        {
            CouponName = coupon.CouponName,
            CouponId = coupon.CouponId,
            CouponDiscount = coupon.CouponDiscount,
            Id = coupon.Id
        };
        return View(couponModel);
    }

    [HttpPost]
    public IActionResult EditCoupon(CouponModel model)
    {
        var coupon = _couponRepository.GetCoupon(model.Id.Value);
        coupon.CouponName = model.CouponName;
        coupon.CouponId = model.CouponId;
        coupon.CouponDiscount = model.CouponDiscount;
        _couponRepository.UpdateCoupon(coupon);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult DeleteCoupon(long id)
    {
        _couponRepository.DeleteCoupon(id);

        return RedirectToAction(nameof(Index));
    }

}

using DataAccess.Repository;
using Domain;
using Microsoft.AspNetCore.Mvc;
using WebDevAPI.Dto;

namespace WebDevAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class CouponController : Controller
{
    private readonly ICouponRepository _couponRepository;
    public CouponController(ICouponRepository couponRepository)
    {
        _couponRepository = couponRepository;
    }

    [HttpGet]
    [Route("GetCoupons")]
    public IActionResult GetCoupons()
    {
        return Ok(_couponRepository.GetCoupons());
    }

    [HttpGet]
    [Route("GetCoupon/{Id}/{userId}")]
    public IActionResult GetCoupon(long Id, string userId)
    {
        var coupon = _couponRepository.GetCoupon(Id);

        //var showProduct = product.(); //TODO

        return Ok(coupon);
    }

    [HttpPost]
    [Route("AddCoupon")]
    public IActionResult AddCoupon([FromBody] CouponDto couponDto)
    {
        var coupon = new Coupon
        {
            CouponName = couponDto.CouponName,
            CouponDiscount = couponDto.CouponDiscount,
            CouponId = couponDto.CouponId,
            Id = couponDto.Id
        };

        _couponRepository.AddCoupon(coupon);

        var result = new CouponDto
        {
            CouponName = couponDto.CouponName,
            CouponDiscount = couponDto.CouponDiscount,
            CouponId = couponDto.CouponId,
            Id = couponDto.Id
        };
        return Ok(result);
    }

    [HttpPost]
    [Route("EditCoupon")]
    public IActionResult EditCoupon([FromBody] CouponDto couponDto)
    {
        var coupon = _couponRepository.GetCoupon(couponDto.Id);
        coupon.Id = couponDto.Id;
        coupon.CouponId = couponDto.CouponId;
        coupon.CouponName = couponDto.CouponName;
        coupon.CouponDiscount = couponDto.CouponDiscount;
        _couponRepository.UpdateCoupon(coupon);
        return Ok(coupon);
    }

    [HttpDelete]
    [Route("DeleteCoupon/{id}")]
    public IActionResult DeleteCoupon(long id)
    {
        _couponRepository.DeleteCoupon(id);
        return Ok();
    }

}

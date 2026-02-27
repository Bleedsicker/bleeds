using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebDev.Configuration;
using WebDev.Dto;
using WebDev.Interfaces;
using WebDev.Models;

namespace WebDev.Controllers;
public class CouponController : Controller
{
    private readonly IApiService _apiService;
    public CouponController(IApiService apiService)
    {
        _apiService = apiService;
    }
    public async Task<IActionResult> Index()
    {
        var response = await _apiService.GetAsync<List<CouponDto>>("Coupons/GetCoupons");

        var result = response.Select(o => new CouponModel
        {
            CouponName = o.CouponName,
            CouponId = o.CouponId,
            CouponDiscount = o.CouponDiscount,
            Id = o.Id,
        }).ToList();

        return View(result);
    }

    [HttpGet]
    public IActionResult AddCoupon()
    {
        return View();
    }

    [HttpPost]
    public async  Task<IActionResult> AddCoupon(CouponModel model)
    {
        var couponDto = new CouponDto
        {
            CouponName = model.CouponName,
            CouponId = model.CouponId,
            CouponDiscount = model.CouponDiscount,
            Id = model.Id
        };

        var response = await _apiService.PostAsync("Coupon/AddCoupon", couponDto);

        if (!response.IsSuccessStatusCode)
        {
            ModelState.AddModelError("", "registration is failed");
            return View(model);
        }
        else
        {
            return RedirectToAction(nameof(Index));
        }
    }

    [HttpGet]
    public IActionResult EditCoupon(CouponDto couponDto)
    {
      
        var couponModel = new CouponModel
        {
            CouponName = couponDto.CouponName,
            CouponId = couponDto.CouponId,
            CouponDiscount = couponDto.CouponDiscount,
            Id = couponDto.Id
        };
        return View(couponModel);
    }

    [HttpPost]
    public async Task<IActionResult> EditCoupon(CouponModel model)
    {
        var couponDto = new CouponDto
        {
            CouponName = model.CouponName,
            CouponId = model.CouponId,
            CouponDiscount = model.CouponDiscount,
            Id= model.Id
        };

        var response = await _apiService.PostAsync("Coupon/EditCoupon", couponDto);

        if (!response.IsSuccessStatusCode)
        {
            ModelState.AddModelError("", "registration is failed");
            return View(model);
        }
        else
        {
            return RedirectToAction(nameof(Index));
        }
    }
    public async Task<IActionResult> DeleteCoupon(long id)
    {
        await _apiService.DeleteAsync($"Coupon/DeleteCoupon/{id}");

        return RedirectToAction(nameof(Index));
    }
}

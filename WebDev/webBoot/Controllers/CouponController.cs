using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebDev.Configuration;
using WebDev.Dto;
using WebDev.Models;

namespace WebDev.Controllers;
public class CouponController : Controller
{
    private readonly ApiSettings _apiSettings;
    public CouponController(ApiSettings apiSettings)
    {
        _apiSettings = apiSettings;
    }
    public async Task<IActionResult> Index()
    {
        var response = await new HttpClient().GetAsync($"{_apiSettings.BaseUrl}/Coupon/GetCoupons");
        if (!response.IsSuccessStatusCode)
        {
            return View(new List<CouponModel>());
        }
        var json = await response.Content.ReadAsStringAsync();

        var couponsDto = JsonSerializer.Deserialize<List<CouponDto>>(json, JsonOptions()) ?? new();
        var result = couponsDto.Select(o => new CouponModel
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

        var response = await new HttpClient().PostAsJsonAsync($"{_apiSettings.BaseUrl}/Coupon/AddCoupon", couponDto);

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

        var response = await new HttpClient().PostAsJsonAsync($"{_apiSettings.BaseUrl}/Coupon/EditCoupon", couponDto);

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
        var httpClient = new HttpClient();
        await httpClient.DeleteAsync($"{_apiSettings.BaseUrl}/Coupon/DeleteCoupon/{id}");

        return RedirectToAction(nameof(Index));
    }
    private static JsonSerializerOptions JsonOptions() => new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };
}

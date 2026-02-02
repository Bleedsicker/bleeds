using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using WebDev.Configuration;
using WebDev.Dto;
using WebDev.Models;

namespace WebDev.Controllers;

public class LoginController : Controller
{
    private readonly ApiSettings _apiSettings;
    public LoginController(ApiSettings apiSettings)
    {
        _apiSettings = apiSettings;
    }

    [HttpGet]
    public IActionResult WelcomePage()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (model.Password != model.PasswordConfirmation)
        {
            ModelState.AddModelError("PasswordConfirmation", "Wrong Password");
            return View(model);
        }
        else
        {
            var userDto = new UserDto
            {
                Username = model.Username,
                Password = model.Password,
            };

            var httpClient = new HttpClient();

            var json = JsonSerializer.Serialize(userDto);
            var httpContent = new StringContent(json,
                Encoding.UTF8,
                "application/json");

            var response = await httpClient.PostAsync($"{_apiSettings.BaseUrl}/User/Register", httpContent);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "registration is failed");
                return View(model);
            }

            var user = await response.Content.ReadFromJsonAsync<UserDto>();

            Authentication(user.Id, user.Username);

            return RedirectToAction(nameof(Login));
        }
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
        var httpClient = new HttpClient();

        var json = JsonSerializer.Serialize(model);
        var httpContent = new StringContent(json,
            Encoding.UTF8,
            "application/json");

        var response = await httpClient.PostAsync($"{_apiSettings.BaseUrl}/User/GetUser", httpContent);

        if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
        {
            ModelState.AddModelError("Password", "Wrong Password");

            return View(model);
        }
        else if (response.StatusCode == System.Net.HttpStatusCode.NotFound &&
            response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            ModelState.AddModelError("Password", "Wrong Password");

            return View(model);
        }
        else
        {
            var user = await response.Content.ReadFromJsonAsync<UserDto>();

            Authentication(user.Id, user.Username);

            return RedirectToAction("Index", "MainMenu");
        }
    }
    private async void Authentication(long id, string username)
    {
        var claims = new List<Claim>();
        var claimId = new Claim("UserId", id.ToString());
        claims.Add(claimId);

        var claimName = new Claim(ClaimTypes.Name, username);
        claims.Add(claimName);

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties()
        {
            IsPersistent = true,
            AllowRefresh = true,
            ExpiresUtc = DateTimeOffset.Now.AddDays(1)
        };

        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

    }
    public async Task<IActionResult> LogOut()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction(nameof(WelcomePage));
    }
}

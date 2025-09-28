using DataAccess.Repository;
using Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebDev.Models;

namespace WebDev.Controllers;

public class LoginController : Controller
{
    private IUserRepository _userRepository;

    public LoginController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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
        if(!ModelState.IsValid)
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
            _userRepository.AddUser(new User
            {
                Password = model.Password,
                Name = model.Username
            });

            Authentication(model);

            return RedirectToAction(nameof(Login));
        }
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model, RegisterModel model1)
    {
        var user = _userRepository.GetUsers().FirstOrDefault(o => o.Name == model.Username);

        if (user != null && user.Password != model.Password)
        {
            ModelState.AddModelError("Password", "Wrong Password");

            return View(model);
        }
        else
        {
            Authentication(model1);
            return RedirectToAction("Index", "MainMenu");
        }
    }

    public async void Authentication(RegisterModel model)
    {
        var claims = new List<Claim>(); //TODO подумать реюз
        var claimName = new Claim(ClaimTypes.Name, model.Username);
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

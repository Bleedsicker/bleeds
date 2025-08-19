using DataAccess.Repository;
using Domain;
using Microsoft.AspNetCore.Mvc;
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
    public IActionResult Register(RegisterModel model)
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

            return RedirectToAction(nameof(Login));
        }
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginModel model)
    {
        var user = _userRepository.GetUsers().FirstOrDefault(o => o.Name == model.Username);

        if (user != null && user.Password != model.Password)
        {
            ModelState.AddModelError("Password", "Wrong Password");

            return View(model);
        }
        else
        {
            return RedirectToAction("MainMenu", "MainMenu");
        }
    }
}

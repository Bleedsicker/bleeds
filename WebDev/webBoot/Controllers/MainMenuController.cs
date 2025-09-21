using Microsoft.AspNetCore.Mvc;

namespace WebDev.Controllers;

public class MainMenuController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}

using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers;

public class DefaultController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
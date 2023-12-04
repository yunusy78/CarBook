using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers;
[Area("Admin")]
public class CalenderController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminDashboardController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
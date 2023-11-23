using CarBook.Dto.Dtos.AboutDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers;

public class AboutController : Controller
{
    
    // GET
    public IActionResult Index()
    {
        ViewBag.v1 = "Om Oss";
        ViewBag.v2 = "Vår Visjon og Misjon";
        return View();
    }
    
    
}
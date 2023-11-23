using CarBook.Dto.Dtos.ServiceDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers;

public class ServiceController : Controller
{
    // GET
    public IActionResult Index()
    {
        ViewBag.v1 = "Tjenester";
        ViewBag.v2 = "Våre Tjenester";
        
        return View();
    }
}
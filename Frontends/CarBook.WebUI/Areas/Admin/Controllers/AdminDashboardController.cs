using Business.Abstract;
using CarBook.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminDashboardController : Controller
{
    private readonly IStatisticService _statisticService;
    
    public AdminDashboardController(IStatisticService statisticService)
    {
        _statisticService = statisticService;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        var carCount = await _statisticService.GetCarCount();
        var brandCount = await _statisticService.GetBrandCount();
        var blogCount = await _statisticService.GetBlogCount();
        var authorCount = await _statisticService.GetAuthorCount();
        var highestPriceCar = await _statisticService.GetHighestPriceCar();
        var lowestPriceCar = await _statisticService.GetLowestPriceCar();
        var mostRentedCarModel = await _statisticService.GetMostRentedCarModel();
        var minRentedCarModel = await _statisticService.GetMinRentedCarModel();
        var model = new AdminDashboardViewModel
        {
            CarCount = carCount,
            BrandCount = brandCount,
            BlogCount = blogCount,
            AuthorCount = authorCount,
            HighestPriceCar = highestPriceCar,
            LowestPriceCar = lowestPriceCar,
            MostRentedCarModel = mostRentedCarModel,
            MinRentedCarModel = minRentedCarModel,
        };
        return View(model);
    }
}
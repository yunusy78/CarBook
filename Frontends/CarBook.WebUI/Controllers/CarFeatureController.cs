using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers;

public class CarFeatureController : Controller
{
    private readonly ICarFeatureService _carFeatureService;
    
    public CarFeatureController(ICarFeatureService carFeatureService)
    {
        _carFeatureService = carFeatureService;
    }
    // GET
    
}
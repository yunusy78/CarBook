using Business.Abstract;
using CarBook.Dto.Dtos.CarDto;
using CarBook.Dto.Dtos.ReservationDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace CarBook.WebUI.Controllers;

public class CarController : Controller
{
    private readonly ICarService _carService;
    
    public CarController(ICarService carService)
    {
        _carService = carService;
    }
    
    // GET
    public async Task<IActionResult> Index(int page=1)
    {
        ViewBag.v1 = "Billiste";
        ViewBag.v2 = "Velg din bil fra vår bil liste";
        var response = await _carService.GetAllAsync();
        if (response != null)
        {
            return View(response.ToPagedList(page, 6));
        }
        return View();
    }
    
    public async Task<IActionResult> Details(int id)
    {
        ViewBag.v1 = "Billiste";
        ViewBag.v2 = "Velg din bil fra vår bil liste";
        var response = await _carService.GetByIdAsync(id);
        if (response != null)
        {
            return View(response);
        }
        return View();
    }
    
    
    public async Task<IActionResult> Reservation(GetReservationCarDto dto, int page=1)
    {
        ViewBag.v1 = "Billiste";
        ViewBag.v2 = "Velg din bil fra vår bil liste";

        var response = await _carService.GetCarWithLocationAndStatus(dto.PickUpLocationId);
        
       
        if (response != null)
        {
            return View(response.ToPagedList(page, 6));
        }
        return View();
    }
    
    public async Task <IActionResult> Pricing()
    {
        ViewBag.v1 = "Billiste";
        ViewBag.v2 = "Velg din bil fra vår bil liste";
        var response = await _carService.GetCarWithPriceBy();
        if (response != null)
        {
            return View(response);
        }
        return View();
    }
}
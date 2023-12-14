using Business.Abstract;
using CarBook.Dto.Dtos.CarDto;
using CarBook.Dto.Dtos.ReservationDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBook.WebUI.Controllers;

public class ReservationCarController : Controller
{
    private readonly IReservationService _reservationService;
    private readonly ICarService _carService;
    private readonly ILocationService _locationService;
    
    public ReservationCarController(IReservationService reservationService, ICarService carService, ILocationService locationService)
    {
        _reservationService = reservationService;
        _carService = carService;
        _locationService = locationService;
    }
    
    
    
    
    // GET
    public async Task<IActionResult> Create(int id)
    {
        var list = new List<SelectListItem>();
        var response = await _locationService.GetAllAsync();
        if (response != null)
        {
            foreach (var value in response)
            {
                list.Add(new SelectListItem(value.Name, value.LocationId.ToString()));
            }
        }
        ViewBag.LocationList = list;
        var car = await _carService.GetByIdAsync(id);
        ViewBag.Car = car;
        TempData["Price"] = car.Price;

        var location = await _locationService.GetByIdAsync(car.LocationId);
        ViewBag.Pickup = location.Name;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateReservationDto dto)
    {
        dto.CustomerId = 2;
        dto.TotalDays = (dto.DropOffDate.Day - dto.PickUpDate.Day);
        dto.TotalPrice = dto.TotalDays * (int)TempData["Price"] ;
        dto.PickUpDescription = dto.PickUpDate.ToString("dd/MM/yyyy");
        dto.DropOffDescription = dto.DropOffDate.ToString("dd/MM/yyyy");
        var response = await _reservationService.CreateReservationAsync(dto);
        if (response)
        {
            TempData["Message"] = "Takk for din melding. Vi vil kontakte deg snart.";
            return Redirect("/ReservationCar/Success");
        }
        return View();
    }
    
    public IActionResult Success()
    {
        
        return View();
    }
    
    
    
}
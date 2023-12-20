using System.IdentityModel.Tokens.Jwt;
using Business.Abstract;
using CarBook.Dto.Dtos.CarDto;
using CarBook.Dto.Dtos.ReservationDto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;

namespace CarBook.WebUI.Controllers;

public class ReservationCarController : Controller
{
    private readonly IReservationService _reservationService;
    private readonly ICarService _carService;
    private readonly ILocationService _locationService;
    private readonly ISharedIdentity _sharedIdentity;
    
    public ReservationCarController(IReservationService reservationService, ICarService carService, ILocationService locationService, ISharedIdentity sharedIdentity)
    {
        _reservationService = reservationService;
        _carService = carService;
        _locationService = locationService;
        _sharedIdentity = sharedIdentity;
    }
    
    
    [Authorize]
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
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(CreateReservationDto dto)
    {
        
        // ID token'ı alınan string formatında bir değişken
        var accessToken = await HttpContext.GetTokenAsync("access_token");

        // ID token'ı çözerek içeriğini kontrol etme
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(accessToken) as JwtSecurityToken;

        // ID token içeriğini inceleme
        if (jsonToken != null)
        {
            // sub alanından kullanıcı kimliğini alın
            string userId = jsonToken.Subject;
            dto.DropOffDescription = userId;
            // Diğer bilgileri almak için gerekli alanlara erişim sağlayabilirsiniz
            // Örneğin, kullanıcının adını almak için jsonToken.Claims'den "name" alanını arayabilirsiniz
        }

        

        dto.CustomerId = 2;
        dto.TotalDays = (dto.DropOffDate.Day - dto.PickUpDate.Day);
        dto.TotalPrice = dto.TotalDays * (int)TempData["Price"]! ;
        dto.PickUpDescription = dto.PickUpDate.ToString("dd/MM/yyyy");
        dto.DropOffDescription = dto.DropOffDate.ToString("dd/MM/yyyy");
        var response = await _reservationService.CreateReservationAsync(dto, accessToken!);
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
using Business.Abstract;
using CarBook.Dto.Dtos.CarDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CarViewComponent;

public class FeeaturedVehiclesViewComponent : ViewComponent
{
    private readonly ICarService _carService;
    
    public FeeaturedVehiclesViewComponent(ICarService carService)
    {
        _carService = carService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await _carService.GetAllAsync();
        if (values != null)
        {
            return View(values!.Skip(values!.Count - 6).ToList());
        }
        else
        {
            return View(new List<CarDto>());
        }
       
    }
    
}
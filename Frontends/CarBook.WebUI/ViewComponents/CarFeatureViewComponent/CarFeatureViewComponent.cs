using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CarFeatureViewComponent;

public class CarFeatureViewComponent : ViewComponent
{
    private readonly ICarFeatureService _carFeatureService;
    
    
    public CarFeatureViewComponent(ICarFeatureService carFeatureService)
    {
        _carFeatureService = carFeatureService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync(int carId)
    {
        var carFeatureList = await _carFeatureService.GetByFilterAsync(carId);
        return View(carFeatureList);
    }
    
    
    
    
    
}
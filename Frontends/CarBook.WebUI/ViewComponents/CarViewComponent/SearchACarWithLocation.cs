using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBook.WebUI.ViewComponents.CarViewComponent;

public class SearchACarWithLocation : ViewComponent
{
    private readonly ICarService _carService;
    private readonly ILocationService _locationService;
    
    public SearchACarWithLocation(ICarService carService, ILocationService locationService)
    {
        _carService = carService;
        _locationService = locationService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
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
        return View();
    }
    
    
}
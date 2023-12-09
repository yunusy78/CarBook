using Business.Abstract;
using CarBook.Dto.Dtos.BlogCategory;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CarViewComponent;

public class CarCategoryCountViewComponent : ViewComponent
{
    private readonly ICarCategoryService _carService;
    
    public CarCategoryCountViewComponent(ICarCategoryService carService)
    {
        _carService = carService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var response = await _carService.GetWithCarCountAsync();
        if (response != null)
        {
            return View(response);
        }
        else
        {
            return View(new List<BlogCategoryCountDto>());
        }
       
       
    }
}
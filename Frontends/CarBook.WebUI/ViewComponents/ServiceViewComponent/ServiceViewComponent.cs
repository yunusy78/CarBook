using Business.Abstract;
using CarBook.Dto.Dtos.ServiceDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.ServiceViewComponent;

public class ServiceViewComponent : ViewComponent
{
    private readonly IServiceService _serviceService;
    
    public ServiceViewComponent(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var response = await _serviceService.GetAllAsync();
        if (response != null)
        {
            return View(response);
            
        }
        return View();
    }
    
    
}
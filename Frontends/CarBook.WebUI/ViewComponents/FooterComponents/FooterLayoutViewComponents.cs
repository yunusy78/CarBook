using Business.Abstract;
using CarBook.Dto.Dtos.FooterDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.FooterComponents;

public class FooterLayoutViewComponents : ViewComponent
{
    private readonly IFooterService _footerService;
    
    
    
    public FooterLayoutViewComponents(IFooterService footerService)
    {
        _footerService = footerService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var response = await _footerService.GetAllAsync();
        
        if (response != null)
        {
            
            return View(response!.Take(1).ToList());
        }
        
        return View();
    }
    
}
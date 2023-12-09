using Business.Abstract;
using CarBook.Dto.Dtos.BannerDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BannerViewComponent;

public class BannerViewComponent : ViewComponent
{
    private readonly IBannerService _bannerService;
    
    
    
    public BannerViewComponent(IBannerService bannerService)
    {
        _bannerService = bannerService;
    }
    
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await _bannerService.GetAllAsync();
        if (values != null)
        {
            
            return View(values!.Take(1).ToList());
            
        }
        return View();
    }
    
}
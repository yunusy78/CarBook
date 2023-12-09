using Business.Abstract;
using CarBook.Dto.Dtos.AboutDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.AboutViewComponent;

public class AboutViewComponent : ViewComponent
{
   private readonly IAboutService _aboutService;

   public AboutViewComponent(IAboutService aboutService)
   {
       _aboutService = aboutService;
   }


   public async Task<IViewComponentResult> InvokeAsync()
    {
        var response = await _aboutService.GetAllAsync();
        
        if (response != null)
        {
            return View(response);
            
        }
        return View();
    }
    
    
}
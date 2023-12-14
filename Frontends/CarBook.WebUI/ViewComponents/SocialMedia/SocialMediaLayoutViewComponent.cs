using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.SocialMedia;

public class SocialMediaLayoutViewComponent : ViewComponent
{
    private readonly ISocialMediaService _socialMediaService;
    
    public SocialMediaLayoutViewComponent(ISocialMediaService socialMediaService)
    {
        _socialMediaService = socialMediaService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var socialMedias = await _socialMediaService.GetAllAsync();
        return View(socialMedias);
    }
    
}
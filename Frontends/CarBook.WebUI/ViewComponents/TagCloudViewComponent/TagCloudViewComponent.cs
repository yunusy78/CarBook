using Business.Abstract;
using CarBook.Dto.Dtos.TagCloud;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.TagCloudViewComponent;

public class TagCloudViewComponent : ViewComponent
{
    private readonly ITagCloudService _tagCloudService;
    
    
    
    public TagCloudViewComponent(ITagCloudService tagCloudService)
    {
        _tagCloudService = tagCloudService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync(int blogId)
    {
        var response = await _tagCloudService.GetByBlogIdAsync(blogId);
        if (response != null)
        {
            return View(response);
        }
        return View();
        
    }
    
    
    
    
}
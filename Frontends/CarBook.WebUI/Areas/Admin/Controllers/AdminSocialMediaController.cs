using Business.Abstract;
using CarBook.Dto.Dtos.SocialMediaDto;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminSocialMediaController : Controller
{
    private readonly ISocialMediaService _SocialMediaService;
    
    public AdminSocialMediaController(ISocialMediaService SocialMediaService)
    {
        _SocialMediaService = SocialMediaService;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var result = await _SocialMediaService.GetAllAsync();
        if (result != null)
        {
            return View(result);
        }
        return View();
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    
    public async Task<IActionResult> Create(SocialMediaDto socialMediaDto)
    {
        
            var result = await _SocialMediaService.AddAsync(socialMediaDto);
            if (result)
            {
                return Redirect("/Admin/AdminSocialMedia/Index");
            }
            
        return View(socialMediaDto);
    }
    
    
    public async Task<IActionResult> Update(int id)
    {
        var socialMedia = await _SocialMediaService.GetByIdAsync(id);
        if (socialMedia != null)
        {
            return View(socialMedia);
        }
        return View();
    }
    
    
    [HttpPost]
    
    public async Task<IActionResult> Update(SocialMediaDto socialMediaDto)
    {
        
            var result = await _SocialMediaService.UpdateAsync(socialMediaDto);
            if (result)
            {
                return Redirect("/Admin/AdminSocialMedia/Index");
            }
        
        return View(socialMediaDto);
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _SocialMediaService.DeleteAsync(id);
        if (result)
        {
            return Redirect("/Admin/AdminSocialMedia/Index");
        }
        return Redirect("/Admin/AdminSocialMedia/Index");
    }
    
}
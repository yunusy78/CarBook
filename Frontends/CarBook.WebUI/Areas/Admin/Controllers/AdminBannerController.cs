using Business.Abstract;
using CarBook.Dto.Dtos.BlogCategory;
using CarBook.Dto.Dtos.BrandDto;
using CarBook.Dto.Dtos.CarCategory;
using CarBook.Dto.Dtos.CarDto;
using CarBook.Dto.Dtos.LocationDto;
using CarBook.Dto.Dtos.BannerDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminBannerController : Controller
{
   private readonly IBannerService _bannerService;

   public AdminBannerController(IBannerService bannerService)
   {
       _bannerService = bannerService;
   }


   // GET
    public async Task<IActionResult> Index()
    {
        var response = await _bannerService.GetAllAsync();
        if (response != null)
        {
            return View(response);
        }
        return View();
    }
    
    [HttpGet]
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    
    public async Task<IActionResult> Create(BannerDto dto, IFormFile file, IFormFile file2)
    {
        if (file != null)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/Banner/" + fileName);
            var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            dto.ImageUrl =@"ImageFile/Banner/"+ fileName;
        }
        else
        {
            dto.ImageUrl = dto.ImageUrl;
        }
        
        if (file2 != null)
        {
            var fileName = Path.GetFileName(file2.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/Banner/" + fileName);
            var stream = new FileStream(filePath, FileMode.Create);
            await file2.CopyToAsync(stream);
            dto.VideoUrl =@"ImageFile/Banner/"+ fileName;
        }
        else
        {
            dto.VideoUrl = dto.VideoUrl;
        }
        
            var response = await _bannerService.AddAsync(dto);
            if (response)
            {
                return Redirect("/Admin/AdminBanner/Index");
            }
        return View(dto);
    }
    
    
    [HttpGet]
    
    public async Task<IActionResult> Update(int id)
    {
        var response = await _bannerService.GetByIdAsync(id);
        if (response != null)
        {
            return View(response);
        }
        return View();
    }
    
    [HttpPost]
    
    public async Task<IActionResult> Update(BannerDto dto, IFormFile file, IFormFile file2)
    {
        if (file != null)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/Banner/" + fileName);
            var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            dto.ImageUrl =@"ImageFile/Banner/"+ fileName;
        }
        else
        {
            dto.ImageUrl = dto.ImageUrl;
        }
        
        if (file2 != null)
        {
            var fileName = Path.GetFileName(file2.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/Banner/" + fileName);
            var stream = new FileStream(filePath, FileMode.Create);
            await file2.CopyToAsync(stream);
            dto.VideoUrl =@"ImageFile/Banner/"+ fileName;
        }
        else
        {
            dto.VideoUrl = dto.VideoUrl;
        }
        
       
            var response = await _bannerService.UpdateAsync(dto);
            if (response)
            {
                return Redirect("/Admin/AdminBanner/Index");
            }
        return View(dto);
    }
    
    
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _bannerService.DeleteAsync(id);
        if (response)
        {
            return Redirect("/Admin/AdminBanner/Index");
        }
        return Redirect("/Admin/AdminBanner/Index");
    }
    
    
    

   
}
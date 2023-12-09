using Business.Abstract;
using CarBook.Dto.Dtos.AboutDto;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminAboutController : Controller
{
    private readonly IAboutService _AboutService;
    
    public AdminAboutController(IAboutService AboutService)
    {
        _AboutService = AboutService;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        var result = await _AboutService.GetAllAsync();
        return View(result);
        
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(AboutDto dto, IFormFile file)
    {
        if (file != null)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/About/" + fileName);
            var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            dto.ImageUrl =@"ImageFile/About/"+ fileName;
        }
        else
        {
            dto.ImageUrl = "default.jpg";
        }
        
       
        var result = await _AboutService.AddAsync(dto);
        if (result)
        {
            return Redirect("/Admin/AdminAbout/Index");
        }
        return View(dto);
    }
    
    public async Task<IActionResult> Update(int id)
    {
        var result = await _AboutService.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return View(result);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Update(AboutDto dto, IFormFile file)
    {
        if (file != null)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/About/" + fileName);
            var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            dto.ImageUrl =@"ImageFile/About/"+ fileName;
        }
        else
        {
            dto.ImageUrl = dto.ImageUrl;
        }
        
        var result = await _AboutService.UpdateAsync(dto);
        if (result)
        {
            return Redirect("/Admin/AdminAbout/Index");
        }
        return View(dto);
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        
        var result = await _AboutService.DeleteAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return Redirect("/Admin/AdminAbout/Index");
    }
    
}
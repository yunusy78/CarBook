using Business.Abstract;
using CarBook.Dto.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminServiceController : Controller
{
    private readonly IServiceService _service;
    
    public AdminServiceController(IServiceService service)
    {
        _service = service;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        var result = await _service.GetAllAsync();
        return View(result);
        
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(ServiceDto dto, IFormFile file)
    {
        if (file != null)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/Service/" + fileName);
            var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            dto.ImageUrl =@"ImageFile/Service/"+ fileName;
        }
        else
        {
            dto.ImageUrl = "default.jpg";
        }
        
        
        var result = await _service.AddAsync(dto);
        if (result)
        {
            return Redirect("/Admin/AdminService/Index");
        }
        return View(dto);
    }
    
    public async Task<IActionResult> Update(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return View(result);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Update(ServiceDto dto, IFormFile file)
    {
        if (file != null)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/Service/" + fileName);
            var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            dto.ImageUrl =@"ImageFile/Service/"+ fileName;
        }
        else
        {
            dto.ImageUrl = dto.ImageUrl;
        }
        
       
        var result = await _service.UpdateAsync(dto);
        if (result)
        {
            return Redirect("/Admin/AdminService/Index");
        }
        return View(dto);
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return Redirect("/Admin/AdminService/Index");
    }
    
}
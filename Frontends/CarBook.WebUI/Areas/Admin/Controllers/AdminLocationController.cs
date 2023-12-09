using Business.Abstract;
using CarBook.Dto.Dtos.LocationDto;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminLocationController : Controller
{
    private readonly ILocationService _service;
    
    public AdminLocationController(ILocationService service)
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
    public async Task<IActionResult> Create(LocationDto dto)
    {
        
        var result = await _service.AddAsync(dto);
        if (result)
        {
            return Redirect("/Admin/AdminLocation/Index");
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
    public async Task<IActionResult> Update(LocationDto dto)
    {
        var result = await _service.UpdateAsync(dto);
        if (result)
        {
            return Redirect("/Admin/AdminLocation/Index");
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
        return Redirect("/Admin/AdminLocation/Index");
    }
    
}
using Business.Abstract;
using CarBook.Dto.Dtos.BrandDto;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminBrandController : Controller
{
    private readonly IBrandService _brandService;
    
    public AdminBrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }
    
    // GET
    public async Task<IActionResult> Index()
    { 
        var response = await _brandService.GetAllAsync();
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
    public async Task<IActionResult> Create(BrandDto brandDto)
    {
        if (ModelState.IsValid)
        {
            var response = await _brandService.AddAsync(brandDto);
            if (response)
            {
                return Redirect("/Admin/AdminBrand/Index");
            }
        }
        return View(brandDto);
    }
    
    
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var response = await _brandService.GetByIdAsync(id);
        if (response != null)
        {
            return View(response);
        }
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(BrandDto brandDto)
    {
        if (ModelState.IsValid)
        {
            var response = await _brandService.UpdateAsync(brandDto);
            if (response)
            {
                return Redirect("/Admin/AdminBrand/Index");
            }
        }
        return View(brandDto);
    }
    
    
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _brandService.DeleteAsync(id);
        if (response)
        {
            return Redirect("/Admin/AdminBrand/Index");
        }
        return Redirect("/Admin/AdminBrand/Index");
        
    }
    
    
}
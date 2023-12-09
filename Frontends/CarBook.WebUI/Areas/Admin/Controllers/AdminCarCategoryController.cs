using Business.Abstract;
using CarBook.Dto.Dtos.CarCategory;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminCarCategoryController : Controller
{
    private readonly ICarCategoryService _carCategoryService;
    
    public AdminCarCategoryController(ICarCategoryService carCategoryService)
    {
        _carCategoryService = carCategoryService;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var carCategories = await _carCategoryService.GetAllAsync();
        if (carCategories != null)
        {
            return View(carCategories);
        }
        
        return View();
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CarCategoryDto carCategoryDto)
    {
        if (ModelState.IsValid)
        {
            var result = await _carCategoryService.AddAsync(carCategoryDto);
            if (result)
            {
                return Redirect("/Admin/AdminCarCategory/Index");
            }
        }
        return View(carCategoryDto);
    }
    
    public async Task<IActionResult> Update(int id)
    {
        var carCategory = await _carCategoryService.GetByIdAsync(id);
        if (carCategory != null)
        {
            return View(carCategory);
        }
        return View();
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Update(CarCategoryDto carCategoryDto)
    {
        if (ModelState.IsValid)
        {
            var result = await _carCategoryService.UpdateAsync(carCategoryDto);
            if (result)
            {
                return Redirect("/Admin/AdminCarCategory/Index");
            }
        }
        return View(carCategoryDto);
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _carCategoryService.DeleteAsync(id);
        if (result)
        {
            return Redirect("/Admin/AdminCarCategory/Index");
        }
        return Redirect("/Admin/AdminCarCategory/Index");
    }
    
}
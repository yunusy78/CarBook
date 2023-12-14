using Business.Abstract;
using CarBook.Dto.Dtos.PricingDto;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminPricingController : Controller
{
    private readonly IPricingService _pricingService;
    
    public AdminPricingController(IPricingService pricingService)
    {
        _pricingService = pricingService;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var result = await _pricingService.GetAllAsync();
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
    
    public async Task<IActionResult> Create(PricingDto pricingDto)
    {
        
            var result = await _pricingService.AddAsync(pricingDto);
            if (result)
            {
                return Redirect("/Admin/AdminPricing/Index");
            }
            
        return View(pricingDto);
    }
    
    
    public async Task<IActionResult> Update(int id)
    {
        var pricing = await _pricingService.GetByIdAsync(id);
        if (pricing != null)
        {
            return View(pricing);
        }
        return View();
    }
    
    
    [HttpPost]
    
    public async Task<IActionResult> Update(PricingDto pricingDto)
    {
        
            var result = await _pricingService.UpdateAsync(pricingDto);
            if (result)
            {
                return Redirect("/Admin/AdminPricing/Index");
            }
        
        return View(pricingDto);
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _pricingService.DeleteAsync(id);
        if (result)
        {
            return Redirect("/Admin/AdminPricing/Index");
        }
        return Redirect("/Admin/AdminPricing/Index");
    }
    
}
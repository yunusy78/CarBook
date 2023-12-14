using Business.Abstract;
using CarBook.Dto.Dtos.CarPricingDto;
using CarBook.Dto.Dtos.PricingDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBook.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminCarPricingController : Controller
{
    private readonly ICarPricingService _pricingService;
    private readonly ICarService _carService;
    private readonly IPricingService _ppricingService;
    
    public AdminCarPricingController(ICarPricingService pricingService, ICarService carService, IPricingService ppricingService)
    {
        _pricingService = pricingService;
        _carService = carService;
        _ppricingService = ppricingService;
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
    
    public async Task<IActionResult> Create()
    {
        var carList = new List<SelectListItem>();
        var response = await _carService.GetAllAsync();
        if (response != null)
        {
            foreach (var value in response)
            {
                carList.Add(new SelectListItem(value.Model, value.CarId.ToString()));
            }
        }
        
        ViewBag.CarList = carList;
        
        var pricingList = new List<SelectListItem>();
        var response2 = await _ppricingService.GetAllAsync();
        if (response2 != null)
        {
            foreach (var value in response2)
            {
                pricingList.Add(new SelectListItem(value.Name, value.PricingId.ToString()));
            }
        }
        
        ViewBag.PricingList = pricingList;
        
        return View();
    }
    
    [HttpPost]
    
    public async Task<IActionResult> Create(CreateCarPricingDto pricingDto)
    {
        
            var result = await _pricingService.AddAsync(pricingDto);
            if (result)
            {
                return Redirect("/Admin/AdminCarPricing/Index");
            }
            
        return View(pricingDto);
    }
    
    
    public async Task<IActionResult> Update(int id)
    {
        var carList = new List<SelectListItem>();
        var response = await _carService.GetAllAsync();
        if (response != null)
        {
            foreach (var value in response)
            {
                carList.Add(new SelectListItem(value.Model, value.CarId.ToString()));
            }
        }
        
        ViewBag.CarList = carList;
        
        var pricingList = new List<SelectListItem>();
        var response2 = await _ppricingService.GetAllAsync();
        if (response2 != null)
        {
            foreach (var value in response2)
            {
                pricingList.Add(new SelectListItem(value.Name, value.PricingId.ToString()));
            }
        }
        
        ViewBag.PricingList = pricingList;
        
        var pricing = await _pricingService.GetByIdAsync(id);
        if (pricing != null)
        {
            return View(pricing);
        }
        return View();
    }
    
    
    [HttpPost]
    
    public async Task<IActionResult> Update(CarPricingDto pricingDto)
    {
        
            var result = await _pricingService.UpdateAsync(pricingDto);
            if (result)
            {
                return Redirect("/Admin/AdminCarPricing/Index");
            }
            return View(pricingDto);
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _pricingService.DeleteAsync(id);
        if (result)
        {
            return Redirect("/Admin/AdminCarPricing/Index");
        }
        return Redirect("/Admin/AdminCarPricing/Index");
    }
    
}
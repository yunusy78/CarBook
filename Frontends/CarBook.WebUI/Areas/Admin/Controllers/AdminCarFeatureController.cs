using Business.Abstract;
using CarBook.Domain.DTOs.CarFeatureDto;
using CarBook.Dto.Dtos.BlogCategory;
using CarBook.Dto.Dtos.BrandDto;
using CarBook.Dto.Dtos.CarCategory;
using CarBook.Dto.Dtos.CarDto;
using CarBook.Dto.Dtos.LocationDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminCarFeatureController : Controller
{
    
    private readonly ICarFeatureService _carFeatureService;
    private readonly IFeatureService _featureService;
    private readonly ICarService _carService;
    
    public AdminCarFeatureController(ICarFeatureService carFeatureService, IFeatureService featureService, ICarService carService)
    {
        _carFeatureService = carFeatureService;
        _featureService = featureService;
        _carService = carService;
    }
    
    
    // GET
    public async Task<IActionResult> Index()
    {
        var response = await _carFeatureService.GetCarFeatureWithCarAndFeatureAsync();
        if (response != null)
        {
            return View(response);
        }
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var list = new List<SelectListItem>();
        var response = await _featureService.GetAllAsync();
        if (response != null)
        {
            foreach (var value in response)
            {
                list.Add(new SelectListItem(value.Name, value.FeatureId.ToString()));
            }
        }
        
        ViewBag.FeatureList = list;
        
        var carList = new List<SelectListItem>();
        var response3 = await _carService.GetAllAsync();
        if (response3 != null)
        {
            foreach (var value in response3)
            {
                carList.Add(new SelectListItem(value.Model, value.CarId.ToString()));
            }
        }
        ViewBag.CarList = carList;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateCarFeatureDto carFeatureDto)
    {
        var response = await _carFeatureService.CreateCarAsync(carFeatureDto);
        if (response)
        {
            return Redirect("/Admin/AdminCarFeature/Index");
        }
        return View();
    }
    
    
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _carFeatureService.DeleteAsync(id);
        if (response)
        {
            return Redirect("/Admin/AdminCarFeature/Index");
        }
        return Redirect("/Admin/AdminCarFeature/Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var list = new List<SelectListItem>();
        var response = await _featureService.GetAllAsync();
        if (response != null)
        {
            foreach (var value in response)
            {
                list.Add(new SelectListItem(value.Name, value.FeatureId.ToString()));
            }
        }
        
        ViewBag.FeatureList = list;
        
        var carList = new List<SelectListItem>();
        var response3 = await _carService.GetAllAsync();
        if (response3 != null)
        {
            foreach (var value in response3)
            {
                carList.Add(new SelectListItem(value.Model, value.CarId.ToString()));
            }
        }
        ViewBag.CarList = carList;
        
        var response2 = await _carFeatureService.GetByIdAsync(id);
        if (response2 != null)
        {
            return View(response2);
        }
        
        return View();
    }
    
    
    [HttpPost]
    
    public async Task<IActionResult> Update(UpdateCarFetaureDto dto)
    {
        var response = await _carFeatureService.UpdateCarAsync(dto);
        if (response)
        {
            return Redirect("/Admin/AdminCarFeature/Index");
        }
        return View();
    }
    
    

   
}
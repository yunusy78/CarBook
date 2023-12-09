using Business.Abstract;
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
public class AdminCarController : Controller
{
    
    private readonly ICarService _carService;
    private readonly ICarCategoryService _carCategoryService;
    private readonly IBrandService _brandService;
    private readonly ILocationService _locationService;
    
    public AdminCarController(ICarService carService, ICarCategoryService carCategoryService, IBrandService brandService, ILocationService locationService)
    {
        _carService = carService;
        _carCategoryService = carCategoryService;
        _brandService = brandService;
        _locationService = locationService;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        var response = await _carService.GetAllAsync();
        if (response != null)
        {
            return View(response);
        }
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var brandList = new List<SelectListItem>();
        var response = await _brandService.GetAllAsync();
        if (response != null)
        {
            foreach (var value in response)
            {
                brandList.Add(new SelectListItem(value.BrandName, value.BrandId.ToString()));
            }
        }
        
        ViewBag.BrandList = brandList;
        var categoryList = new List<SelectListItem>();
        var response2 = await _carCategoryService.GetAllAsync();
        if (response2 != null)
        {
            foreach (var value in response2)
            {
                categoryList.Add(new SelectListItem(value.Name, value.CategoryId.ToString()));
            }
        }
        
        ViewBag.CategoryList = categoryList;
        
        var locationList = new List<SelectListItem>();
        var response3 = await _locationService.GetAllAsync();
        if (response3 != null)
        {
            foreach (var value in response3)
            {
                locationList.Add(new SelectListItem(value.Name, value.LocationId.ToString()));
            }
        }
        ViewBag.LocationList = locationList;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateCarDto carDto, IFormFile? file)
    {
        if (file != null)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/Car/" + fileName);
            var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            carDto.ImageUrl =@"ImageFile/Car/"+ fileName;
        }
        else
        {
            carDto.ImageUrl = "default.jpg";
        }
        var response = await _carService.AddAsync(carDto);
        if (response)
        {
            return Redirect("/Admin/AdminCar/Index");

        }
        return View();
    }
    
    
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _carService.DeleteAsync(id);
        if (response)
        {
            return Redirect("/Admin/AdminCar/Index");
        }
        return Redirect("/Admin/AdminCar/Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var brandList = new List<SelectListItem>();
        var response = await _brandService.GetAllAsync();
        if (response != null)
        {
            foreach (var value in response)
            {
                brandList.Add(new SelectListItem(value.BrandName, value.BrandId.ToString()));
            }
        }
        
        ViewBag.BrandList = brandList;
        var categoryList = new List<SelectListItem>();
        var response2 = await _carCategoryService.GetAllAsync();
        if (response2 != null)
        {
            foreach (var value in response2)
            {
                categoryList.Add(new SelectListItem(value.Name, value.CategoryId.ToString()));
            }
        }
        
        ViewBag.CategoryList = categoryList;
        
        var locationList = new List<SelectListItem>();
        var response3 = await _locationService.GetAllAsync();
        if (response3 != null)
        {
            foreach (var value in response3)
            {
                locationList.Add(new SelectListItem(value.Name, value.LocationId.ToString()));
            }
        }
        ViewBag.LocationList = locationList;
        
        var car = await _carService.GetByIdAsync(id);
        if (car != null)
        {
            return View(car);
        }
        
        return View();
    }
    
    
    [HttpPost]
    
    public async Task<IActionResult> Update(UpdateCarDto carDto, IFormFile? file)
    {
        if (file != null)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/Car/" + fileName);
            var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            carDto.ImageUrl =@"ImageFile/Car/"+ fileName;
        }
        else
        {
            carDto.ImageUrl = carDto.ImageUrl;
        }
        var response = await _carService.UpdateAsync(carDto);
        if (response)
        {
            return Redirect("/Admin/AdminCar/Index");

        }
        return View();
    }
    
    

   
}
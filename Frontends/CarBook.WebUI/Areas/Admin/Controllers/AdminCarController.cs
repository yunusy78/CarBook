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
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _configuration;
    
    public AdminCarController(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        _configuration = configuration;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Car.Path}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<CarDto>>(jsonContent);
            return View(values);
        }
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var brandList = new List<SelectListItem>();
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Brand.Path}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<BrandDto>>(jsonContent);
            foreach (var value in values)
            {
                brandList.Add(new SelectListItem(value.BrandName, value.BrandId.ToString()));
            }
        }
        ViewBag.BrandList = brandList;
        var categoryList = new List<SelectListItem>();
        response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.CarCategory.Path}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<CarCategoryDto>>(jsonContent);
            foreach (var value in values)
            {
                categoryList.Add(new SelectListItem(value.Name, value.CategoryId.ToString()));
            }
        }
        ViewBag.CategoryList = categoryList;
        
        var locationList = new List<SelectListItem>();
        response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Location.Path}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<LocationDto>>(jsonContent);
            foreach (var value in values)
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
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            carDto.ImageUrl = fileName;
        }
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PostAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Car.Path}", carDto);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    

   
}
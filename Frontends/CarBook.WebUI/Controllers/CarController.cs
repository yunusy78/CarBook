using CarBook.Dto.Dtos.CarDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace CarBook.WebUI.Controllers;

public class CarController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    public CarController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    // GET
    public async Task<IActionResult> Index(int page=1)
    {
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var client = _httpClientFactory.CreateClient();
        ViewBag.v1 = "Billiste";
        ViewBag.v2 = "Velg din bil fra vår bil liste";
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Car.Path}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<CarDto>>(jsonContent);
            
            return View(values.ToPagedList(page, 6));
            
        }
        
        return View();
    }
    
    public async Task <IActionResult> Pricing()
    {
        ViewBag.v1 = "Billiste";
        ViewBag.v2 = "Velg din bil fra vår bil liste";
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Car.Path}/withpricing");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<CarDto>>(jsonContent);
            return View(value);
        }
        
        return View();
    }
}
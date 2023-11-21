using CarBook.Dto.Dtos.ServiceDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers;

public class ServiceController : Controller
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration configuration;
    
    public ServiceController(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        this.configuration = configuration;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        ViewBag.v1 = "Tjenester";
        ViewBag.v2 = "Våre Tjenester";
        var serviceApiSettings = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Service.Path}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ServiceDto>>(jsonContent);
            return View(values);
            
        }
        return View();
    }
}
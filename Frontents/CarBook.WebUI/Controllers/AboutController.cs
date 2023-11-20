using CarBook.Dto.Dtos.AboutDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers;

public class AboutController : Controller
{
    private readonly IHttpClientFactory _clientFactory;
    
    public AboutController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5047/api/Abouts");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<AboutDto>>(jsonContent);
            return View(values);
            
        }
        return View();
    }
}
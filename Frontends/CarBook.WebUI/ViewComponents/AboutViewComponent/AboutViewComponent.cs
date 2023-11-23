using CarBook.Dto.Dtos.AboutDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.AboutViewComponent;

public class AboutViewComponent : ViewComponent
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration configuration;
    
    public AboutViewComponent(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        this.configuration = configuration;
    }
    
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var serviceApiSettings = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.About.Path}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<AboutDto>>(jsonContent);
            return View(values);
            
        }
        return View();
    }
    
    
}
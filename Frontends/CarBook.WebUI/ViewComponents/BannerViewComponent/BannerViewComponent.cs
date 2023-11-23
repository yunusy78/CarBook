using CarBook.Dto.Dtos.BannerDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BannerViewComponent;

public class BannerViewComponent : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    public BannerViewComponent(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Banner.Path}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<BannerDto>>(jsonContent);
            
            return View(values!.Take(1).ToList());
            
        }
        return View();
    }
    
}
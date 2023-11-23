using CarBook.Dto.Dtos.FooterDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.FooterComponents;

public class AddressViewComponent : ViewComponent
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _configuration;
    
    public AddressViewComponent(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        _configuration = configuration;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var apiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync($"{apiSettings!.BaseUri}/{apiSettings.Footer.Path}");
        
        if (response.IsSuccessStatusCode)
        {
            var responseStream = await response.Content.ReadAsStringAsync();
            var footer = JsonConvert.DeserializeObject<List<FooterDto>>(responseStream);
            return View(footer!.Take(1).ToList());
        }
        
        return View();
    }
    
}
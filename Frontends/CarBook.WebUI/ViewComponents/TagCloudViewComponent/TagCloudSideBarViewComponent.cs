using CarBook.Dto.Dtos.TagCloud;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.TagCloudViewComponent;

public class TagCloudSideBarViewComponent : ViewComponent
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _configuration;
    
    
    public TagCloudSideBarViewComponent(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        _configuration = configuration;
    }
    
    public async Task<IViewComponentResult> InvokeAsync(int blogId)
    {
        var apiSetting = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync($"{apiSetting!.BaseUri}/{apiSetting.TagCloud.Path}/GetTagCloudByBlogId/{blogId}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<TagCloudDto>>(jsonContent);
            return View(values);
            
        }
        return View();
        
    }
    
    
    
    
}
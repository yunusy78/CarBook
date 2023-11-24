using CarBook.Dto.Dtos.BlogDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace CarBook.WebUI.Controllers;

public class BlogController : Controller
{
    
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _configuration;
    
    public BlogController(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        _configuration = configuration;
    }
    
    public async Task<IActionResult> Index(int page=1)
    {
        ViewBag.v1 = "Blogg";
        ViewBag.v2 = "Her kan du lese om våre nye blogginnlegg";
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Blog.Path}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<BlogDto>>(jsonContent);
            return View(values.ToPagedList(page, 3));
            
        }
        return View();
    }
    
    public async Task<IActionResult> Details(int id)
    {
        ViewBag.v1 = "Blogg";
        ViewBag.v2 = "Her kan du lese om våre nye blogginnlegg";
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Blog.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<BlogDto>(jsonContent);
            return View(value);
            
        }
        return View();
    }
}
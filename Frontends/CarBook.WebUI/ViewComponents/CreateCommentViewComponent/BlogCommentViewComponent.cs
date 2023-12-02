using CarBook.Dto.Dtos.CommentDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CreateCommentViewComponent;

public class BlogCommentViewComponent : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    public BlogCommentViewComponent(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public async Task<IViewComponentResult> InvokeAsync(int blogId)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Comment.Path}/withBlog/{blogId}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<CommentDto>>(jsonContent);
            return View(values);
        }
        return View();
    }
    
}
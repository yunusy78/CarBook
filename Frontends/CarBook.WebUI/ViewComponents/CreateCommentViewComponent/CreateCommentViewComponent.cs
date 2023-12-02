using CarBook.Dto.Dtos.CommentDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CreateCommentViewComponent;

public class CreateCommentViewComponent : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    public CreateCommentViewComponent(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public async Task<IViewComponentResult> InvokeAsync(CommentDto commentDto)
    {
        commentDto.CreatedAt = DateTime.Now;
        var apiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var client = _httpClientFactory.CreateClient();
        var response = await client.PostAsJsonAsync($"{apiSettings!.BaseUri}/{apiSettings.Comment.Path}", commentDto);
        
        if (response.IsSuccessStatusCode)
        {
            TempData["Message"] = "Takk for din melding. Vi vil kontakte deg snart.";
            return View();
        }
        ViewBag.Error = "Noe gikk galt. Vennligst prøv igjen.";
        return View();
    }
    
    
}
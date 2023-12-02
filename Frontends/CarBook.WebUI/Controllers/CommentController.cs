using CarBook.Dto.Dtos.CommentDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers;

public class CommentController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    public CommentController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public PartialViewResult CreateComment()
    {
        return PartialView();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateComment([FromBody] CommentDto commentDto)
    {
        commentDto.CreatedAt = DateTime.Now;
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PostAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Comment.Path}", commentDto);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Details", "Blog", new {id = commentDto.BlogId});
        }
        ViewBag.Error = "Noe gikk galt. Vennligst prøv igjen.";
        return PartialView();
    }
    

}
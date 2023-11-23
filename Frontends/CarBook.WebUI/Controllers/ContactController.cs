using CarBook.Dto.Dtos.ContactDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers;

public class ContactController : Controller
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _configuration;
    
    public ContactController(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        _configuration = configuration;
    }
    
    
    
    public IActionResult Index()
    {
        ViewBag.V1 = "Kontakt";
        ViewBag.V2 = "Kontakt med oss";
        ViewBag.Success = TempData["Message"];
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Index(ContactDto contactDto)
    {
        contactDto.CreatedAt = DateTime.Now;
        var apiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var client = _clientFactory.CreateClient();
        var response = await client.PostAsJsonAsync($"{apiSettings!.BaseUri}/{apiSettings.Contact.Path}", contactDto);
        
        if (response.IsSuccessStatusCode)
        {
            TempData["Message"] = "Takk for din melding. Vi vil kontakte deg snart.";
            return RedirectToAction("Index");
        }
        ViewBag.Error = "Noe gikk galt. Vennligst prøv igjen.";
        return View();
    }
}
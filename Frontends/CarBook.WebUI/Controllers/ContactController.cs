using Business.Abstract;
using CarBook.Dto.Dtos.ContactDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _contactService;
    
    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
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
        var response = await _contactService.AddAsync(contactDto);
        if (response != null)
        {
            TempData["Message"] = "Takk for din melding. Vi vil kontakte deg snart.";
            return RedirectToAction("Index");
        }
        ViewBag.Error = "Noe gikk galt. Vennligst prøv igjen.";
        return View();
    }
}
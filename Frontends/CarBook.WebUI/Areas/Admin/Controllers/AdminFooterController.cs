using Business.Abstract;
using CarBook.Dto.Dtos.BlogCategory;
using CarBook.Dto.Dtos.BrandDto;
using CarBook.Dto.Dtos.CarCategory;
using CarBook.Dto.Dtos.CarDto;
using CarBook.Dto.Dtos.LocationDto;
using CarBook.Dto.Dtos.FooterDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminFooterController : Controller
{
   private readonly IFooterService _footerService;

   public AdminFooterController(IFooterService footerService)
   {
       _footerService = footerService;
   }


   // GET
    public async Task<IActionResult> Index()
    {
        var response = await _footerService.GetAllAsync();
        if (response != null)
        {
            return View(response);
        }
        return View();
    }
    
    [HttpGet]
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    
    public async Task<IActionResult> Create(FooterDto dto)
    {
        var response = await _footerService.AddAsync(dto);
        if (response)
        {
            return Redirect("/Admin/AdminFooter/Index");
        }
        return View(dto);
    }
   
    
    
    [HttpGet]
    
    public async Task<IActionResult> Update(int id)
    {
        var response = await _footerService.GetByIdAsync(id);
        if (response != null)
        {
            return View(response);
        }
        return View();
    }
    
    [HttpPost]
    
    public async Task<IActionResult> Update(FooterDto dto)
    {
            var response = await _footerService.UpdateAsync(dto);
            if (response)
            {
                return Redirect("/Admin/AdminFooter/Index");
            }
        return View(dto);
    }
    
    
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _footerService.DeleteAsync(id);
        if (response)
        {
            return Redirect("/Admin/AdminFooter/Index");
        }
        return Redirect("/Admin/AdminFooter/Index");
    }
    
    
    

   
}
using Business.Abstract;
using CarBook.Dto.Dtos.BlogDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace CarBook.WebUI.Controllers;

public class BlogController : Controller
{
    
   private readonly IBlogService _blogService;

   public BlogController(IBlogService blogService)
   {
       _blogService = blogService;
   }


   public async Task<IActionResult> Index(int page=1)
    {
        ViewBag.v1 = "Blogg";
        ViewBag.v2 = "Her kan du lese om våre nye blogginnlegg";
        var response = await _blogService.GetAllAsync();
        if (response != null)
        {
            return View(response.ToPagedList(page, 3));
        }
        return View();
    }
    
    public async Task<IActionResult> Details(int id)
    {
        ViewBag.v1 = "Blogg";
        ViewBag.v2 = "Her kan du lese om våre nye blogginnlegg";
        ViewBag.BlogId = id;
        var response = await _blogService.GetByIdAsync(id);
        if (response != null)
        {
            return View(response);
            
        }
        return View();
    }
}
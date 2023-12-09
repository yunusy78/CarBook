using Business.Abstract;
using CarBook.Dto.Dtos.BlogCategory;
using CarBook.Dto.Dtos.BrandDto;
using CarBook.Dto.Dtos.CarCategory;
using CarBook.Dto.Dtos.CarDto;
using CarBook.Dto.Dtos.LocationDto;
using CarBook.Dto.Dtos.AuthorDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminAuthorController : Controller
{
   private readonly IAuthorService _authorService;

   public AdminAuthorController(IAuthorService authorService)
   {
       _authorService = authorService;
   }


   // GET
    public async Task<IActionResult> Index()
    {
        var response = await _authorService.GetAllAsync();
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
    
    public async Task<IActionResult> Create(AuthorDto dto, IFormFile file)
    {
        if (file != null)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/Author/" + fileName);
            var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            dto.ImageUrl =@"ImageFile/Author/"+ fileName;
        }
        else
        {
            dto.ImageUrl = dto.ImageUrl;
        }
        
            var response = await _authorService.AddAsync(dto);
            if (response)
            {
                return Redirect("/Admin/AdminAuthor/Index");
            }
        return View(dto);
    }
    
    
    [HttpGet]
    
    public async Task<IActionResult> Update(int id)
    {
        var response = await _authorService.GetByIdAsync(id);
        if (response != null)
        {
            return View(response);
        }
        return View();
    }
    
    [HttpPost]
    
    public async Task<IActionResult> Update(AuthorDto dto, IFormFile file)
    {
        if (file != null)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/Author/" + fileName);
            var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            dto.ImageUrl =@"ImageFile/Author/"+ fileName;
        }
        else
        {
            dto.ImageUrl = dto.ImageUrl;
        }
        
       
            var response = await _authorService.UpdateAsync(dto);
            if (response)
            {
                return Redirect("/Admin/AdminAuthor/Index");
            }
        return View(dto);
    }
    
    
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _authorService.DeleteAsync(id);
        if (response)
        {
            return Redirect("/Admin/AdminAuthor/Index");
        }
        return Redirect("/Admin/AdminAuthor/Index");
    }
    
    
    

   
}
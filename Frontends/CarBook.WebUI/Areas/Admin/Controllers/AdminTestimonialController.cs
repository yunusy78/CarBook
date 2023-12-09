using Business.Abstract;
using CarBook.Dto.Dtos.BlogCategory;
using CarBook.Dto.Dtos.BrandDto;
using CarBook.Dto.Dtos.CarCategory;
using CarBook.Dto.Dtos.CarDto;
using CarBook.Dto.Dtos.LocationDto;
using CarBook.Dto.Dtos.TestimonialDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminTestimonialController : Controller
{
   private readonly ITestimonialService _testimonialService;

   public AdminTestimonialController(ITestimonialService testimonialService)
   {
       _testimonialService = testimonialService;
   }


   // GET
    public async Task<IActionResult> Index()
    {
        var response = await _testimonialService.GetAllAsync();
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
    
    public async Task<IActionResult> Create(TestimonialDto testimonialDto, IFormFile file)
    {
        if (file != null)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/Testimonial/" + fileName);
            var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            testimonialDto.ImageUrl =@"ImageFile/Testimonial/"+ fileName;
        }
        else
        {
            testimonialDto.ImageUrl = testimonialDto.ImageUrl;
        }
        
            var response = await _testimonialService.AddAsync(testimonialDto);
            if (response)
            {
                return Redirect("/Admin/AdminTestimonial/Index");
            }
        return View(testimonialDto);
    }
    
    
    [HttpGet]
    
    public async Task<IActionResult> Update(int id)
    {
        var response = await _testimonialService.GetByIdAsync(id);
        if (response != null)
        {
            return View(response);
        }
        return View();
    }
    
    [HttpPost]
    
    public async Task<IActionResult> Update(TestimonialDto testimonialDto, IFormFile file)
    {
        if (file != null)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/Testimonial/" + fileName);
            var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            testimonialDto.ImageUrl =@"ImageFile/Testimonial/"+ fileName;
        }
        else
        {
            testimonialDto.ImageUrl = testimonialDto.ImageUrl;
        }
        
       
            var response = await _testimonialService.UpdateAsync(testimonialDto);
            if (response)
            {
                return Redirect("/Admin/AdminTestimonial/Index");
            }
        return View(testimonialDto);
    }
    
    
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _testimonialService.DeleteAsync(id);
        if (response)
        {
            return Redirect("/Admin/AdminTestimonial/Index");
        }
        return Redirect("/Admin/AdminTestimonial/Index");
    }
    
    
    

   
}
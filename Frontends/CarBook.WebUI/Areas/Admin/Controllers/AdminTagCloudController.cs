using Business.Abstract;
using CarBook.Dto.Dtos.TagCloud;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBook.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminTagCloudController : Controller
{
    private readonly ITagCloudService _tagCloudService;
    private readonly IBlogService _blogService;
    
    public AdminTagCloudController(ITagCloudService tagCloudService, IBlogService blogService)
    {
        _tagCloudService = tagCloudService;
        _blogService = blogService;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        var tagClouds = await _tagCloudService.GetAllAsync();
        return View(tagClouds);
        
    }
    
    public async Task<IActionResult> Create()
    {
        var blogList = new List<SelectListItem>();
        var response=   await _blogService.GetAllAsync();
         
         if (response != null)
         {
             foreach (var value in response)
             {
                 blogList.Add(new SelectListItem(value.Title, value.BlogId.ToString()));
             }
         }
         
        ViewBag.BlogList = blogList;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(TagCloudDto tagCloudDto)
    {
       
        var result = await _tagCloudService.AddAsync(tagCloudDto);
        if (result)
        {
            return Redirect("/Admin/AdminTagCloud/Index");
        }
        return View(tagCloudDto);
    }
    
    public async Task<IActionResult> Update(int id)
    {
        
        var blogList = new List<SelectListItem>();
        var response=   await _blogService.GetAllAsync();
         
        if (response != null)
        {
            foreach (var value in response)
            {
                blogList.Add(new SelectListItem(value.Title, value.BlogId.ToString()));
            }
        }
         
        ViewBag.BlogList = blogList;
        
        var tagCloud = await _tagCloudService.GetByIdAsync(id);
        if (tagCloud == null)
        {
            return NotFound();
        }
        return View(tagCloud);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Update(TagCloudDto tagCloudDto)
    {
       
        var result = await _tagCloudService.UpdateAsync(tagCloudDto);
        if (result)
        {
            return Redirect("/Admin/AdminTagCloud/Index");
        }
        return View(tagCloudDto);
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var tagCloud = await _tagCloudService.DeleteAsync(id);
        if (tagCloud == null)
        {
            return NotFound();
        }
        return Redirect("/Admin/AdminTagCloud/Index");
    }
    
}
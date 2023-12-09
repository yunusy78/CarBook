using Business.Abstract;
using CarBook.Dto.Dtos.BlogCategory;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminBlogCategoryController : Controller
{
    private readonly IBlogCategoryService _blogCategoryService;
    
    public AdminBlogCategoryController(IBlogCategoryService blogCategoryService)
    {
        _blogCategoryService = blogCategoryService;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var blogCategories = await _blogCategoryService.GetAllAsync();
        if (blogCategories != null)
        {
            return View(blogCategories);
        }
        return View();
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    
    public async Task<IActionResult> Create(BlogCategoryDto blogCategoryDto)
    {
        
            var result = await _blogCategoryService.AddAsync(blogCategoryDto);
            if (result)
            {
                return Redirect("/Admin/AdminBlogCategory/Index");
            }
            
        return View(blogCategoryDto);
    }
    
    
    public async Task<IActionResult> Update(int id)
    {
        var blogCategory = await _blogCategoryService.GetByIdAsync(id);
        if (blogCategory != null)
        {
            return View(blogCategory);
        }
        return View();
    }
    
    
    [HttpPost]
    
    public async Task<IActionResult> Update(BlogCategoryDto blogCategoryDto)
    {
        
            var result = await _blogCategoryService.UpdateAsync(blogCategoryDto);
            if (result)
            {
                return Redirect("/Admin/AdminBlogCategory/Index");
            }
        
        return View(blogCategoryDto);
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _blogCategoryService.DeleteAsync(id);
        if (result)
        {
            return Redirect("/Admin/AdminBlogCategory/Index");
        }
        return Redirect("/Admin/AdminBlogCategory/Index");
    }
    
}
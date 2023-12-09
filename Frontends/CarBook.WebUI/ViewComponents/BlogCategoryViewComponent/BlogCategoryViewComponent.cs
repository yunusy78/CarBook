using Business.Abstract;
using CarBook.Dto.Dtos.BlogCategory;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogCategoryViewComponent;

public class BlogCategoryViewComponent : ViewComponent
{
    private readonly IBlogCategoryService _blogCategoryService;
    
    
    public BlogCategoryViewComponent(IBlogCategoryService blogCategoryService)
    {
        _blogCategoryService = blogCategoryService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await _blogCategoryService.GetBlogCategoryCountAsync();
        if (values != null)
        {
            
            return View(values);
            
        }
        return View();
    }
    
}
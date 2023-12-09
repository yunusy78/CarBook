using Business.Abstract;
using CarBook.Dto.Dtos.BlogDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBook.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminBlogController : Controller
{
    private readonly IBlogService _blogService;
    private readonly IBlogCategoryService _blogCategoryService;
    private readonly IAuthorService _authorService;

    public AdminBlogController(IBlogService blogService, IBlogCategoryService blogCategoryService, IAuthorService authorService)
    {
        _blogService = blogService;
        _blogCategoryService = blogCategoryService;
        _authorService = authorService;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var blogs = await _blogService.GetAllAsync();
        if (blogs != null)
        {
            return View(blogs);
        }

        return View();
    }

    public async Task<IActionResult> Create()
    {
        var blogCategoryList = new List<SelectListItem>();
        var response = await _blogCategoryService.GetAllAsync();
        if (response != null)
        {
            foreach (var value in response)
            {
                blogCategoryList.Add(new SelectListItem(value.Name, value.BlogCategoryId.ToString()));
            }
        }
        
        ViewBag.BlogCategoryList = blogCategoryList;
        
        var authorList = new List<SelectListItem>();
        var response2 = await _authorService.GetAllAsync();
        if (response2 != null)
        {
            foreach (var value in response2)
            {
                authorList.Add(new SelectListItem((value.FirstName + value.LastName) , value.AuthorId.ToString()));
            }
        }
        
        ViewBag.AuthorList = authorList;
        
        return View();
    }

    [HttpPost]

    public async Task<IActionResult> Create(BlogDto blogDto, IFormFile file1, IFormFile file2)
    {
       
            if (file1 != null)
            {
                var fileName = Path.GetFileName(file1.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/Blog/" + fileName);
                var stream = new FileStream(filePath, FileMode.Create);
                await file1.CopyToAsync(stream);
                blogDto.ImageUrl =@"ImageFile/Blog/"+ fileName;
            }
            else
            {
                blogDto.ImageUrl = "default.jpg";
            }
            
            if (file2 != null)
            {
                var fileName = Path.GetFileName(file2.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/Blog/" + fileName);
                var stream = new FileStream(filePath, FileMode.Create);
                await file2.CopyToAsync(stream);
                blogDto.CoverImage=@"ImageFile/Blog/"+ fileName;
            }
            else
            {
                blogDto.CoverImage = "default.jpg";
            }
            
            var result = await _blogService.AddAsync(blogDto);
            
            if (result)
            {
                return Redirect("/Admin/AdminBlog/Index");
            }

        return View(blogDto);
    }


    public async Task<IActionResult> Update(int id)
    {
        var blogCategoryList = new List<SelectListItem>();
        var response = await _blogCategoryService.GetAllAsync();
        if (response != null)
        {
            foreach (var value in response)
            {
                blogCategoryList.Add(new SelectListItem(value.Name, value.BlogCategoryId.ToString()));
            }
        }
        
        ViewBag.BlogCategoryList = blogCategoryList;
        
        var authorList = new List<SelectListItem>();
        var response2 = await _authorService.GetAllAsync();
        if (response2 != null)
        {
            foreach (var value in response2)
            {
                authorList.Add(new SelectListItem((value.FirstName + value.LastName) , value.AuthorId.ToString()));
            }
        }
        
        ViewBag.AuthorList = authorList;
        
        var blog = await _blogService.GetByIdAsync(id);
        if (blog != null)
        {
            return View(blog);
        }

        return View();
    }


    [HttpPost]

    public async Task<IActionResult> Update(BlogDto blogDto, IFormFile file1, IFormFile file2)
    {
        if (ModelState.IsValid)
        {
            if (file1 != null)
            {
                var fileName = Path.GetFileName(file1.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/Blog/" + fileName);
                var stream = new FileStream(filePath, FileMode.Create);
                await file1.CopyToAsync(stream);
                blogDto.ImageUrl =@"ImageFile/Blog/"+ fileName;
            }
            else
            {
                blogDto.ImageUrl = blogDto.ImageUrl;
            }
            
            if (file2 != null)
            {
                var fileName = Path.GetFileName(file2.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/Blog/" + fileName);
                var stream = new FileStream(filePath, FileMode.Create);
                await file2.CopyToAsync(stream);
                blogDto.CoverImage=@"ImageFile/Blog/"+ fileName;
            }
            else
            {
                blogDto.CoverImage = blogDto.CoverImage;
            }
            var result = await _blogService.UpdateAsync(blogDto);
            if (result)
            {
                return Redirect("/Admin/AdminBlog/Index");
            }
        }

        return View(blogDto);
    }


    public async Task<IActionResult> Delete(int id)
    {
        var result = await _blogService.DeleteAsync(id);
        if (result)
        {
            return Redirect("/Admin/AdminBlog/Index");
        }

        return Redirect("/Admin/AdminBlog/Index");
    }

}
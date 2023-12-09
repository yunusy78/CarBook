using Business.Abstract;
using CarBook.Dto.Dtos.CommentDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CreateCommentViewComponent;

public class BlogCommentViewComponent : ViewComponent
{
    private readonly ICommentService _commentService;
    
    public BlogCommentViewComponent(ICommentService commentService)
    {
        _commentService = commentService;
    }

    public async Task<IViewComponentResult> InvokeAsync(int blogId)
    {
        var values = await _commentService.GetAllWithSubCommentsAsync(blogId);
        if (values != null)
        {
            return View(values);
        }
        else
        {
            return View(new List<CommentDto>());
        }
    }

}
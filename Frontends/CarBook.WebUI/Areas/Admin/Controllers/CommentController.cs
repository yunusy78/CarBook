using Business.Abstract;
using CarBook.Dto.Dtos.CommentDto;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class CommentController : Controller
{
    private readonly ICommentService _commentService;
    
    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        var comments = await _commentService.GetAllAsync();
        return View(comments);
    }
    
    public async Task<IActionResult> Detail(int id)
    {
        var comment = await _commentService.GetAllWithSubCommentsAsync(id);
        return View(comment);
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        await _commentService.DeleteAsync(id);
        return Redirect($"/Admin/Comment/Index/");
    }
    
    public async Task<IActionResult> Update(int id)
    {
        var comment = await _commentService.GetByIdAsync(id);
        return View(comment);
    }
    
    [HttpPost]
    
    public async Task<IActionResult> Update(CommentDto commentDto)
    {
        await _commentService.UpdateAsync(commentDto);
        return Redirect($"/Admin/Comment/Index/");
    }
}
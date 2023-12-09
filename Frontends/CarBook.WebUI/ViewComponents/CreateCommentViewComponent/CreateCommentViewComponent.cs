using Business.Abstract;
using CarBook.Dto.Dtos.CommentDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CreateCommentViewComponent;

public class CreateCommentViewComponent : ViewComponent
{
    private readonly ICommentService _commentService;
    
    
    public CreateCommentViewComponent(ICommentService commentService)
    {
        _commentService = commentService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync(CommentDto commentDto)
    {
        commentDto.CreatedAt = DateTime.Now;
        
        var response = await _commentService.AddAsync(commentDto);
        
        if (response)
        {
            TempData["Message"] = "Takk for din melding. Vi vil kontakte deg snart.";
            return View();
        }
        ViewBag.Error = "Noe gikk galt. Vennligst prøv igjen.";
        return View();
    }
    
    
}
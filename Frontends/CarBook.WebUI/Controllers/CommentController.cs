using Business.Abstract;
using CarBook.Dto.Dtos.CommentDto;
using CarBook.Dto.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers;

public class CommentController : Controller
{
   private readonly ICommentService _commentService;

   public CommentController(ICommentService commentService)
   {
       _commentService = commentService;
   }


   public PartialViewResult CreateComment()
    {
        return PartialView();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateComment([FromBody] CommentDto commentDto)
    {
        commentDto.CreatedAt = DateTime.Now;
        var response = await _commentService.AddAsync(commentDto);
        if (response != null)
        {
            return RedirectToAction("Details", "Blog", new {id = commentDto.BlogId});
        }
        ViewBag.Error = "Noe gikk galt. Vennligst prøv igjen.";
        return PartialView();
    }
    

}
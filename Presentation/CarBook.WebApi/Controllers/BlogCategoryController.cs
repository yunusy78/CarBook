using CarBook.Application.Features.Mediator.Commands.BlogCategoryCommands;
using CarBook.Application.Features.Mediator.Queries.BlogCategoryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public BlogCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetBlogCategory()
        {
            var result = await _mediator.Send(new GetBlogCategoryQuery());
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogCategoryById(int id)
        {
            var result = await _mediator.Send(new GetBlogCategoryByIdQuery(id));
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateBlogCategory(CreateBlogCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok("BlogCategory Created Successfully");
        }
        
        [HttpPut]
        
        public async Task<IActionResult> UpdateBlogCategory(UpdateBlogCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok("BlogCategory Updated Successfully");
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogCategory(int id)
        {
            await _mediator.Send(new DeleteBlogCategoryCommand(id));
            return Ok("BlogCategory Deleted Successfully");
        }
        
        
    }
}

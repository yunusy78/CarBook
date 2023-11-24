using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            var result = await _mediator.Send(new GetBlogWithCategoryAndAuthorQuery());
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var result = await _mediator.Send(new GetBlogByIdWithCategoryAndAuthorQuery(id));
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog Created Successfully");
        }
        
        [HttpPut]
        
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog Updated Successfully");
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _mediator.Send(new DeleteBlogCommand(id));
            return Ok("Blog Deleted Successfully");
        }
        
        [HttpGet("last3")]
        public async Task<IActionResult> GetLast3Blogs()
        {
            var result = await _mediator.Send(new GetLast3BlogWithCategoryAndAuthorQuery());
            return Ok(result);
        }
        
        [HttpGet("categoryCount")]
        
        public async Task<IActionResult> GetBlogCountByCategory()
        {
            var result = await _mediator.Send(new GetBlogsCategoryCountQuery());
            return Ok(result);
        }
        
        
    }
}

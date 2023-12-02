using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudsController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public TagCloudsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetTagClouds()
        {
            var result = await _mediator.Send(new GetTagCloudQuery());
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagCloudById(int id)
        {
            var result = await _mediator.Send(new GetTagCloudByIdQuery(id));
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("TagCloud Created Successfully");
        }
        
        [HttpPut]
        
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("TagCloud Updated Successfully");
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTagCloud(int id)
        {
            await _mediator.Send(new DeleteTagCloudCommand(id));
            return Ok("TagCloud Deleted Successfully");
        }


        [HttpGet("GetTagCloudByBlogId/{blogId}")]
        public async Task<IActionResult> GetTagCloudByBlogId(int blogId)
        {
            var result = await _mediator.Send(new GetTagCloudByBlogIdQuery(blogId));
            return Ok(result);
        }


    }
}

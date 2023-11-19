using CarBook.Application.Features.Mediator.Commands.FooterCommands;
using CarBook.Application.Features.Mediator.Queries.FooterQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootersController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public FootersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetFooters()
        {
            var result = await _mediator.Send(new GetFooterQuery());
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterById(int id)
        {
            var result = await _mediator.Send(new GetFooterByIdQuery(id));
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateFooter(CreateFooterCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer Created Successfully");
        }
        
        [HttpPut]
        
        public async Task<IActionResult> UpdateFooter(UpdateFooterCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer Updated Successfully");
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFooter(int id)
        {
            await _mediator.Send(new DeleteFooterCommand(id));
            return Ok("Footer Deleted Successfully");
        }
        
        
    }
}

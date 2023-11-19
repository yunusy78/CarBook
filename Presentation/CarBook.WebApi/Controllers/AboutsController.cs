using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.About;
using CarBook.Application.Features.CQRS.Queries.About;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _createAboutCommandHandler;
        private readonly DeleteAboutCommandHandler _deleteAboutCommandHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandler _getAboutsQueryHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        
        
        public AboutsController(CreateAboutCommandHandler createAboutCommandHandler, 
            DeleteAboutCommandHandler deleteAboutCommandHandler, 
            GetAboutByIdQueryHandler getAboutByIdQueryHandler, 
            GetAboutQueryHandler getAboutsQueryHandler, 
            UpdateAboutCommandHandler updateAboutCommandHandler)
        {
            _createAboutCommandHandler = createAboutCommandHandler;
            _deleteAboutCommandHandler = deleteAboutCommandHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _getAboutsQueryHandler = getAboutsQueryHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAbouts()
        {
            var abouts = await _getAboutsQueryHandler.Handle();
            return Ok(abouts);
        }
        
        
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            var about = await _getAboutByIdQueryHandler.Handle( new GetAboutByIdQuery(id));
            return Ok(about);
        }
        
        [HttpPost]
        
        public async Task<IActionResult> CreateAbout(CreateAboutCommand request)
        {
            await _createAboutCommandHandler.Handle(request);
            return Ok("About created successfully");
        }
        
        
        [HttpPut]
        
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommands request)
        {
            await _updateAboutCommandHandler.Handle(request);
            return Ok("About updated successfully");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _deleteAboutCommandHandler.Handle(new DeleteAboutCommands(id));
            return Ok("About deleted successfully");
        }



    }
}

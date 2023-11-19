using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly GetContactQueryHandler  _getContactQueryHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly DeleteContactCommandHandler _deleteContactCommandHandler;
        
        
        
        public ContactsController(GetContactQueryHandler getContactQueryHandler, 
            GetContactByIdQueryHandler getContactByIdQueryHandler, 
            CreateContactCommandHandler createContactCommandHandler, 
            UpdateContactCommandHandler updateContactCommandHandler, 
            DeleteContactCommandHandler deleteContactCommandHandler)
        {
            _getContactQueryHandler = getContactQueryHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _createContactCommandHandler = createContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _deleteContactCommandHandler = deleteContactCommandHandler;
        }
        
       
        
        [HttpGet]
        
        public async Task<IActionResult> GetAll()
        {
            var banners = await _getContactQueryHandler.Handle();
            return Ok(banners);
        }
        
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            var banner = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(banner);
        }
        
        [HttpPost]
        
        public async Task<IActionResult> Create(CreateContactCommand request)
        {
            await _createContactCommandHandler.Handle(request);
            return Ok("Contact created successfully");
        }
        
        
        [HttpPut]
        
        public async Task<IActionResult> Update(UpdateContactCommand request)
        {
            await _updateContactCommandHandler.Handle(request);
            return Ok("Contact updated successfully");
        }
        
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeleteContactCommand(id);
            await _deleteContactCommandHandler.Handle(request);
            return Ok("Contact deleted successfully");
        }
        
    }
}

using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly GetCarQueryHandler  _getCarQueryHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly DeleteCarCommandHandler _deleteCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        
        
        
        public CarsController(GetCarQueryHandler getCarQueryHandler, 
            GetCarByIdQueryHandler getCarByIdQueryHandler, 
            CreateCarCommandHandler createCarCommandHandler, 
            UpdateCarCommandHandler updateCarCommandHandler, 
            DeleteCarCommandHandler deleteCarCommandHandler, 
            GetCarWithBrandQueryHandler getCarWithBrandQueryHandler)
        {
            _getCarQueryHandler = getCarQueryHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _createCarCommandHandler = createCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _deleteCarCommandHandler = deleteCarCommandHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
        }
       
        
        [HttpGet]
        
        public async Task<IActionResult> GetAll()
        {
            var banners = await _getCarWithBrandQueryHandler.Handle();
            return Ok(banners);
        }
        
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            var car = await _getCarByIdQueryHandler.Handle(id);
            return Ok(car);
        }
        
        [HttpPost]
        
        public async Task<IActionResult> Create(CreateCarCommand request)
        {
            await _createCarCommandHandler.Handle(request);
            return Ok("Car created successfully");
        }
        
        
        [HttpPut]
        
        public async Task<IActionResult> Update(UpdateCarCommand request)
        {
            await _updateCarCommandHandler.Handle(request);
            return Ok("Car updated successfully");
        }
        
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeleteCarCommand(id);
            await _deleteCarCommandHandler.Handle(request);
            return Ok("Car deleted successfully");
        }
        
    }
}
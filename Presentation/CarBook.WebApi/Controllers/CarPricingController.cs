using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using CarBook.Application.Interfaces;
using CarBook.Domain.DTOs.CarPricingDto;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingController : ControllerBase
    {
        private readonly ICarPricingRepository _carPricingRepository;
        
        
        public CarPricingController(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPricing()
        {
            var result = await _carPricingRepository.GetAllAsync();
            return result != null ? Ok(result) : NotFound();
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricingById(int id)
        {
            var result = await _carPricingRepository.GetByIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreateCarPricingDto command)
        {
            await _carPricingRepository.CreateCarPricingAsync(command);
            return Ok("Pricing Created Successfully");
        }
        
        [HttpPut]
        
        public async Task<IActionResult> UpdatePricing(UpdateCarPricingDto command)
        {
            await _carPricingRepository.UpdateCarPricingAsync(command);
            return Ok("Pricing Updated Successfully");
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePricing(int id)
        {
            var pricing = await _carPricingRepository.GetByIdAsync(id);
            await _carPricingRepository.DeleteAsync(pricing);
            return Ok("Pricing Deleted Successfully");
        }
        
        
    }
}

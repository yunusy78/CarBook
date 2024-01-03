using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Interfaces;
using CarBook.Domain.DTOs.CarFeatureDto;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly ICarFeatureRepository _carFeatureRepository;
        private readonly IMapper _mapper;
       
        
        public CarFeaturesController(ICarFeatureRepository carFeatureRepository, IMapper mapper)
        {
            _carFeatureRepository = carFeatureRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetFeatures()
        {
            var result = await _carFeatureRepository.GetAllAsync();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(int id)
        {
            var result = await _carFeatureRepository.GetByIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateCarFeatureDto dto)
        {
            await _carFeatureRepository.CreateCarPricingAsync(dto);
            return Ok("Feature Created Successfully");
        }
        
        [HttpPut]
        
        public async Task<IActionResult> UpdateFeature(UpdateCarFetaureDto dto)
        {
            await _carFeatureRepository.UpdateCarPricingAsync(dto);
            return Ok("Feature Updated Successfully");
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            await _carFeatureRepository.DeleteAsync(new CarFeature{CarFeatureId = id});
            return Ok("Feature Deleted Successfully");
        }
        
        [HttpGet("GetCarFeatureWithCarAndFeature")]
        public async Task<IActionResult> GetCarFeatureWithCarAndFeature()
        {
            var result = await _carFeatureRepository.GetCarFeatureWithCarAndFeatureAsync();
            return Ok(result);
        }
        
        [HttpGet("GetByFilter/{id}")]
        
        public async Task<IActionResult> GetByFilter(int id)
        {
            var result = await _carFeatureRepository.GetByFilterAsync(id);
            return Ok(result);
        }
        
        
    }
}

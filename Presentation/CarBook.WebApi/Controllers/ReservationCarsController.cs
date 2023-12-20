
using CarBook.Application.Interfaces;
using CarBook.Dto.Dtos.ReservationDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationCarsController : ControllerBase
    {
        
        private readonly IReservationCarRepository _reservationCarRepository;
        
        public ReservationCarsController(IReservationCarRepository reservationCarRepository)
        {
            _reservationCarRepository = reservationCarRepository;
        }
        
        [HttpGet]
        
        public async Task<IActionResult> GetAll()
        {
            var result = await _reservationCarRepository.GetAllAsync();
            return Ok(result);
        }
        
        [HttpGet("withCarAndLocationAndStatusAndPricing")]
        
        public async Task<IActionResult> GetReservationCarWithCarAndLocationAndStatusAndPricing()
        {
            var result = await _reservationCarRepository.GetReservationCarWithCarAndLocationAndStatusAndPricingAsync();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _reservationCarRepository.GetByIdAsync(id);
            return Ok(result);
        }
        
        
        
        [Authorize]
        [HttpPost]
        
        public async Task<IActionResult> Create(CreateReservationDto request)
        {
            await _reservationCarRepository.CreateReservationAsync(request);
            return Ok("ReservationCar created successfully");
        }
        
        
        [HttpPut]
        
        public async Task<IActionResult> Update(UpdateReservationDto request)
        {
            await _reservationCarRepository.UpdateReservationAsync(request);
            return Ok("ReservationCar updated successfully");
        }
        
        
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> Delete(int id)
        {
           var result= await _reservationCarRepository.GetByIdAsync(id);
           await _reservationCarRepository.DeleteAsync(result);
            return Ok("ReservationCar deleted successfully");
        }
        
        
        [HttpGet("withLocationAndStatus/{locationId}")]
        
        public async Task<IActionResult> GetWithLocationAndStatus(int locationId)
        {

            var cars = await _reservationCarRepository.GetByFilterAsync(x=>x.PickUpLocationId==locationId && x.Car.IsAvailable==true);
            return Ok(cars);
        }
        
        
        
        
        
    }
}

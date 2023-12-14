using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.DTOs.CarPricingDto;
using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces;

public interface ICarPricingRepository : IGenericRepository<CarPricingDto>
{
    Task CreateCarPricingAsync(CreateCarPricingDto carPricingDto);
    Task UpdateCarPricingAsync(UpdateCarPricingDto carPricingDto);
    
    
    
}
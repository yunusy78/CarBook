using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.DTOs.CarFeatureDto;
using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces;

public interface ICarFeatureRepository : IGenericRepository<CarFeature>
{
    
    Task CreateCarPricingAsync(CreateCarFeatureDto carPricingDto);
    Task UpdateCarPricingAsync(UpdateCarFetaureDto carPricingDto);
    
    Task <List<CarFeature>>GetCarFeatureWithCarAndFeatureAsync();
    
    
}
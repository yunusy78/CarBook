using CarBook.Dto.Dtos.CarPricingDto;

namespace Business.Abstract;

public interface ICarPricingService : IGenericService<CarPricingDto>
{
    Task<bool> AddAsync(CreateCarPricingDto carPricingDto);
    Task<bool> UpdateAsync(CarPricingDto carPricingDto);
    
}
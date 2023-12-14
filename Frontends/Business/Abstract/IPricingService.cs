using CarBook.Dto.Dtos.PricingDto;

namespace Business.Abstract;

public interface IPricingService : IGenericService<PricingDto>
{
    Task<bool> AddAsync(PricingDto pricingDto);
    Task<bool> UpdateAsync(PricingDto pricingDto);
    
}
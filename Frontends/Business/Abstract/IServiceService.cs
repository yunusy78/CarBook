using CarBook.Dto.Dtos.ServiceDto;

namespace Business.Abstract;

public interface IServiceService : IGenericService<ServiceDto>
{
    
    Task<bool> AddAsync(ServiceDto serviceDto);
    Task<bool> UpdateAsync(ServiceDto serviceDto);
    
}
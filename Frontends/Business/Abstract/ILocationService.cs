using CarBook.Dto.Dtos.LocationDto;

namespace Business.Abstract;

public interface ILocationService : IGenericService<LocationDto>
{
    
    Task<bool> AddAsync(LocationDto locationDto);
    Task<bool> UpdateAsync(LocationDto locationDto);
    
}
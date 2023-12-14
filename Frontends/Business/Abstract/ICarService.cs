using CarBook.Dto.Dtos.CarDto;

namespace Business.Abstract;

public interface ICarService : IGenericService<CarDto>
{
    Task<bool> AddAsync(CreateCarDto entity);
    Task<bool> UpdateAsync(UpdateCarDto entity);

    Task<List<CarDto>> GetCarWithPriceBy();
    
    Task<List<CarDto>> GetCarWithLocationAndStatus(int locationId);
}
using CarBook.Domain.DTOs.CarFeatureDto;
using CarBook.Domain.Entities;
using CarBook.Dto.Dtos.CarFeatureDto;
using CreateCarFeatureDto = CarBook.Domain.DTOs.CarFeatureDto.CreateCarFeatureDto;

namespace Business.Abstract;

public interface ICarFeatureService : IGenericService<GetCarFeatureDto>
{
    Task<bool> CreateCarAsync(CreateCarFeatureDto dto);
    Task<bool> UpdateCarAsync(UpdateCarFetaureDto dto);
    Task <List<GetCarFeatureDto>>GetCarFeatureWithCarAndFeatureAsync();
    
    Task<List<GetCarFeatureDto>>  GetByFilterAsync(int id);
}
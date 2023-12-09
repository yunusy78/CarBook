using CarBook.Dto.Dtos.BlogCategory;
using CarBook.Dto.Dtos.CarCategory;

namespace Business.Abstract;

public interface ICarCategoryService : IGenericService<CarCategoryDto>
{
    Task<bool> AddAsync(CarCategoryDto categoryDto);
    Task<bool> UpdateAsync(CarCategoryDto categoryDto);
    
    Task<List<BlogCategoryCountDto>> GetWithCarCountAsync();
    
}
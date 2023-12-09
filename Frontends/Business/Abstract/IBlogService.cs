using CarBook.Dto.Dtos.BlogCategory;
using CarBook.Dto.Dtos.BlogDto;
using CarBook.Dto.Dtos.CarCategory;

namespace Business.Abstract;

public interface IBlogService : IGenericService<BlogDto>
{
    Task<bool> AddAsync(BlogDto blogDto);
    Task<bool> UpdateAsync(BlogDto blogDto);
    
}
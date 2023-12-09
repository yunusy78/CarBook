using CarBook.Dto.Dtos.BlogCategory;
using CarBook.Dto.Dtos.CarCategory;

namespace Business.Abstract;

public interface IBlogCategoryService : IGenericService<BlogCategoryDto>
{
    Task<bool> AddAsync(BlogCategoryDto categoryDto);
    Task<bool> UpdateAsync(BlogCategoryDto categoryDto);
    
    Task<List<BlogCategoryCountDto>> GetBlogCategoryCountAsync();
    
}
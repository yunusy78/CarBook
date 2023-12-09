using CarBook.Dto.Dtos.TagCloud;

namespace Business.Abstract;

public interface ITagCloudService : IGenericService<TagCloudDto>
{
    
    Task<bool> AddAsync(TagCloudDto tagCloudDto);
    Task<bool> UpdateAsync(TagCloudDto tagCloudDto);
    
    Task<List<TagCloudDto>> GetByBlogIdAsync(int blogId);
    
}
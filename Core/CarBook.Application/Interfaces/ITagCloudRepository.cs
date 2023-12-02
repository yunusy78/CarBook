using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces;

public interface ITagCloudRepository
{
    
    List<TagCloud> GetTagCloudByBlogId(int blogId);
    
}
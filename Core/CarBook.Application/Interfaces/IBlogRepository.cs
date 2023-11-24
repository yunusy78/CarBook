using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces;

public interface IBlogRepository
{
    
    Task<List<Blog>> GetBlogsWithCategoryAndAuthorAsync();
    
    Task<Blog> GetByIdWithCategoryAndAuthorAsync(int id);
    
    Task<List<Blog>> GetLast3BlogsWithCategoryAndAuthorAsync();


    Dictionary<string, int> GetBlogCountByCategory();


}
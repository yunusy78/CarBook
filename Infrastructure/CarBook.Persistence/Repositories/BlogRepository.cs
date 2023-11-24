using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories;

public class BlogRepository : IBlogRepository
{
    private readonly CarBookDbContext _context;
    
    public BlogRepository(CarBookDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Blog>> GetBlogsWithCategoryAndAuthorAsync()
    {
        var blogs = await _context.Blogs
            .Include(b => b.Category)
            .Include(b => b.Author)
            .ToListAsync();
        return blogs;
    }
    
    public async Task<Blog> GetByIdWithCategoryAndAuthorAsync(int id)
    {
        var blog = await _context.Blogs
            .Include(b => b.Category)
            .Include(b => b.Author)
            .FirstOrDefaultAsync(b => b.BlogId == id);
        return blog!;
    }
    
    public async Task<List<Blog>> GetLast3BlogsWithCategoryAndAuthorAsync()
    {
        var blogs = await _context.Blogs
            .Include(b => b.Category)
            .Include(b => b.Author).Take(3).ToListAsync();
        return blogs;
    }
    
    public  Dictionary<string, int> GetBlogCountByCategory()
    {
        var blogCounts = _context.Blogs
            .GroupBy(b => b.Category.Name)
            .Select(g => new { Category = g.Key, Count = g.Count() })
            .ToDictionary(x => x.Category, x => x.Count);

        return blogCounts;
    }
    
}
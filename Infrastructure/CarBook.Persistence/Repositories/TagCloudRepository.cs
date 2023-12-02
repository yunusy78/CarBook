using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repositories;

public class TagCloudRepository : ITagCloudRepository
{
    private readonly CarBookDbContext _context;
    
    public TagCloudRepository(CarBookDbContext context)
    {
        _context = context;
    }
    
    public List<TagCloud> GetTagCloudByBlogId(int blogId)
    {
        var tagClouds = _context.TagClouds.Where(x => x.BlogId == blogId).ToList();
        return tagClouds;
    }
}
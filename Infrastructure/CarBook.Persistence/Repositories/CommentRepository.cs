using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.DTOs;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly CarBookDbContext _dbContext;
    
    public CommentRepository(CarBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Comment>> GetAllAsync()
    {
        var comments = await _dbContext.Comments.Select(x => new Comment
        {
            CommentId = x.CommentId,
            Name = x.Name,
            Description = x.Description,
            CreatedAt = x.CreatedAt,
            Message = x.Message,
            BlogId = x.BlogId

        }).ToListAsync();
        return comments;
    }

    public async Task<Comment> GetByIdAsync(int id)
    {
        var comment = await _dbContext.Comments.FindAsync(id);
        var result = new Comment
        {
            CommentId = comment!.CommentId,
            Name = comment.Name,
            Description = comment.Description,
            CreatedAt = comment.CreatedAt,
            Message = comment.Message,
            BlogId = comment.BlogId
        };
        return result;
    }

    public async Task AddAsync(Comment entity)
    {
        var comment = new Comment
        {
            CommentId = entity.CommentId,
            Name = entity.Name,
            Description = entity.Description,
            CreatedAt = entity.CreatedAt,
            Message = entity.Message,
            BlogId = entity.BlogId
        };
        await _dbContext.Set<Comment>().AddAsync(comment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Comment entity)
    {
        var comment = await GetByIdAsync(entity.CommentId);
        comment.Name = entity.Name;
        comment.Description = entity.Description;
        comment.CreatedAt = entity.CreatedAt;
        comment.Message = entity.Message;
        comment.BlogId = entity.BlogId;
        _dbContext.Set<Comment>().Update(comment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Comment entity)
    {
        var existingComment = _dbContext.Comments.Local.FirstOrDefault(c => c.CommentId == entity.CommentId);

        if (existingComment != null)
        {
            _dbContext.Comments.Remove(existingComment);
            await _dbContext.SaveChangesAsync();
        }
    }

    public Task<List<CommentDto>> GetCommentsByBlogId(int blogId)
    {
        var comments = _dbContext.Comments.Where(x => x.BlogId == blogId).Select(x => new CommentDto
        {
            CommentId = x.CommentId,
            Name = x.Name,
            Description = x.Description,
            CreatedAt = x.CreatedAt,
            Message = x.Message,
            BlogId = x.BlogId
        }).ToListAsync();
        return comments;
    }
}
using CarBook.Domain.DTOs;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.RepositoryPattern;

public interface ICommentRepository : IGenericRepository<Comment>
{
    Task<List<CommentDto>> GetCommentsByBlogId(int blogId);
    
}
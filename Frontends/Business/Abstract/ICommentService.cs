using CarBook.Dto.Dtos.CommentDto;
using CarBook.Dto.Dtos.CarCategory;

namespace Business.Abstract;

public interface ICommentService : IGenericService<CommentDto>
{
    Task<bool> AddAsync(CommentDto commentDto);
    Task<bool> UpdateAsync(CommentDto commentDto);
    
    Task<List<CommentDto>> GetAllWithSubCommentsAsync(int blogId);
    
}
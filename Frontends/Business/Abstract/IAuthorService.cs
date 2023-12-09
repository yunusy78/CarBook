

using CarBook.Dto.Dtos.AuthorDto;
using CarBook.Dto.Dtos.BrandDto;

namespace Business.Abstract;

public interface IAuthorService : IGenericService<AuthorDto>
{
        
        Task<bool> AddAsync(AuthorDto entity);
        Task<bool> UpdateAsync(AuthorDto entity);
    
}
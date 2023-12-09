using CarBook.Dto.Dtos.AboutDto;

namespace Business.Abstract;

public interface IAboutService : IGenericService<AboutDto>
{
    
    Task<bool> AddAsync(AboutDto aboutDto);
    Task<bool> UpdateAsync(AboutDto aboutDto);
    
}
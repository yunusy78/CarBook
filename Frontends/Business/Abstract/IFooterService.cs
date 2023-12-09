using CarBook.Dto.Dtos.FooterDto;

namespace Business.Abstract;

public interface IFooterService : IGenericService<FooterDto>
{
    
    Task<bool> AddAsync(FooterDto footerDto);
    Task<bool> UpdateAsync(FooterDto footerDto);
    
}
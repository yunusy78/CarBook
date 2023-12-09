using CarBook.Dto.Dtos.BrandDto;

namespace Business.Abstract;

public interface IBrandService : IGenericService<BrandDto>
{
        
        Task<bool> AddAsync(BrandDto entity);
        Task<bool> UpdateAsync(BrandDto entity);
    
}
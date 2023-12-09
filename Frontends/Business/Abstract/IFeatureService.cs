using CarBook.Dto.Dtos.FeatureDto;

namespace Business.Abstract;

public interface IFeatureService : IGenericService<FeatureDto>
{
    
    Task<bool> AddAsync(FeatureDto entity);
    Task<bool> UpdateAsync(FeatureDto entity);
    
}
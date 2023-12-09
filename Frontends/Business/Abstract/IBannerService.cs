using CarBook.Dto.Dtos.BannerDto;

namespace Business.Abstract;

public interface IBannerService : IGenericService<BannerDto>
{
    
    Task<bool> AddAsync(BannerDto bannerDto);
    Task<bool> UpdateAsync(BannerDto bannerDto);
    
}
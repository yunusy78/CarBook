using CarBook.Dto.Dtos.SocialMediaDto;

namespace Business.Abstract;

public interface ISocialMediaService : IGenericService<SocialMediaDto>
{
    
    Task<bool> AddAsync(SocialMediaDto socialMediaDto);
    Task<bool> UpdateAsync(SocialMediaDto socialMediaDto);
    
    
}
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers;

public class GetBannerByIdQueryHandler
{
    private readonly IRepository<Banner> _bannerRepository;
    
    public GetBannerByIdQueryHandler(IRepository<Banner> bannerRepository)
    {
        _bannerRepository = bannerRepository;
    }
    
    
    public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery request)
    {
        var banner = await _bannerRepository.GetByIdAsync(request.BannerId);
        
        var bannerDto = new GetBannerByIdQueryResult()
        {
            BannerId = banner.BannerId,
            Title = banner.Title,
            Description = banner.Description,
            ImageUrl = banner.ImageUrl,
            VideoTitle = banner.VideoTitle,
            VideoUrl = banner.VideoUrl,
            
        };
        
        return bannerDto;
    }
    
    
    
}
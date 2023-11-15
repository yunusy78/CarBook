using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Interfaces;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers;

public class GetBannerQueryHandler
{
    private readonly IRepository<Domain.Entities.Banner> _repository;
    
    public GetBannerQueryHandler(IRepository<Domain.Entities.Banner> repository)
    {
        _repository = repository;
    }
    
    
    public async Task<List<GetBannerQueryResult>> Handle()
    {
        var banners = await _repository.ListAllAsync();
        var bannerResults = banners.Select(banner => new GetBannerQueryResult
        {
            BannerId = banner.BannerId,
            ImageUrl = banner.ImageUrl,
            Title = banner.Title,
            Description = banner.Description,
            VideoTitle = banner.VideoTitle,
            VideoUrl = banner.VideoUrl
        }).ToList();
        return bannerResults;
    }
    
    
    
}
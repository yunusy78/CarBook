using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers;

public class UpdateBannerCommandHandler
{
    private readonly IRepository<Banner> _bannerRepository;
    
    public UpdateBannerCommandHandler(IRepository<Banner> bannerRepository)
    {
        _bannerRepository = bannerRepository;
    }
    
    public async Task Handle(UpdateBannerCommand request)
    {
        var banner = await _bannerRepository.GetByIdAsync(request.BannerId);
        
        banner.Title = request.Title;
        banner.Description = request.Description;
        banner.ImageUrl = request.ImageUrl;
        banner.VideoTitle = request.VideoTitle;
        banner.VideoUrl = request.VideoUrl;
        
        await _bannerRepository.UpdateAsync(banner);
    }
    
}
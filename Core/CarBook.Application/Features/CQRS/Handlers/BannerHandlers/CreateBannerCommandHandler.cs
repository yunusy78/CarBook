using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers;

public class CreateBannerCommandHandler
{
    private readonly IRepository<Banner> _bannerRepository;
    
    public CreateBannerCommandHandler(IRepository<Banner> bannerRepository)
    {
        _bannerRepository = bannerRepository;
    }
    
    public async Task Handle(CreateBannerCommand request)
    {
        var banner = new Banner()
        {
            Title = request.Title,
            Description = request.Description,
            ImageUrl = request.ImageUrl,
            VideoTitle = request.VideoTitle,
            VideoUrl = request.VideoUrl,
        };
        
        await _bannerRepository.AddAsync(banner);
    }
    
}
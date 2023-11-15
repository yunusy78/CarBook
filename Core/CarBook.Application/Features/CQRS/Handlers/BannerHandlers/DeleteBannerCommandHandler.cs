using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers;

public class DeleteBannerCommandHandler
{
    private readonly IRepository<Banner> _bannerRepository;
    
    public DeleteBannerCommandHandler(IRepository<Banner> bannerRepository)
    {
        _bannerRepository = bannerRepository;
    }
    
    public async Task Handle(DeleteBannerCommand request)
    {
        var banner = await _bannerRepository.GetByIdAsync(request.BannerId);
        
        await _bannerRepository.DeleteAsync(banner);
    }
    
}
using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;

namespace CarBook.Application.Features.CQRS.Handlers.About;

public class DeleteAboutCommandHandler
{
    private readonly IRepository<Domain.Entities.About> _aboutRepository;

    public DeleteAboutCommandHandler(IRepository<Domain.Entities.About> aboutRepository)
    {
        _aboutRepository = aboutRepository;
    }

    public async Task Handle(DeleteAboutCommands request)
    {
        var about = await _aboutRepository.GetByIdAsync(request.AboutId);
        await _aboutRepository.DeleteAsync(about);
    }
    
}
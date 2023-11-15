using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;

namespace CarBook.Application.Features.CQRS.Handlers.About;

public class CreateAboutCommandHandler
{
    private readonly IRepository<Domain.Entities.About> _repository;
    
    public CreateAboutCommandHandler(IRepository<Domain.Entities.About> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(CreateAboutCommand request)
    {
        var about = new Domain.Entities.About
        {
            Title = request.Title,
            Description = request.Description,
            ImageUrl = request.ImageUrl
        };
        
        await _repository.AddAsync(about);
        
    }
    
    
}
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
{
    private readonly IRepository<SocialMedia> _repository;
    
    public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var socialMedia = new SocialMedia
        {
            Name = request.Name,
            Url = request.Url,
            Icon = request.Icon,
            
        };
        await _repository.AddAsync(socialMedia);
    }
}

using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers;


public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
{
    private readonly IRepository<SocialMedia> _repository;
    
    public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
    {
      var socialMedia = await _repository.GetByIdAsync(request.SocialMediaId);
        socialMedia.Name = request.Name;
        socialMedia.Url = request.Url;
        socialMedia.Icon = request.Icon;
      await _repository.UpdateAsync(socialMedia);
    }
}

using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;

public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
{
    private readonly IRepository<Feature> _featureRepository;
    
    public CreateFeatureCommandHandler(IRepository<Feature> featureRepository)
    {
        _featureRepository = featureRepository;
    }
    
    public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
    {
        var feature = new Feature
        {
            Name = request.Name
        };
        await _featureRepository.AddAsync(feature);
    }
}

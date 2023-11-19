using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;

public class DeleteFeatureCommandHandler : IRequestHandler<DeleteFeatureCommand>
{
    private readonly IRepository<Feature> _featureRepository;
    
    public DeleteFeatureCommandHandler(IRepository<Feature> featureRepository)
    {
        _featureRepository = featureRepository;
    }
    
    public async Task Handle(DeleteFeatureCommand request, CancellationToken cancellationToken)
    {
        var feature = await _featureRepository.GetByIdAsync(request.FeatureId);
       await _featureRepository.DeleteAsync(feature);
    }
}
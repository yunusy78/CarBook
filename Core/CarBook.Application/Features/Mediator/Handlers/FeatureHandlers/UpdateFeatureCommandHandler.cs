using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;


public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
{
    private readonly IRepository<Feature> _featureRepository;
    
    public UpdateFeatureCommandHandler(IRepository<Feature> featureRepository)
    {
        _featureRepository = featureRepository;
    }
    
    public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
    {
      var feature = await _featureRepository.GetByIdAsync(request.FeatureId);
      feature.Name = request.Name;
      await _featureRepository.UpdateAsync(feature);
      
    }
}

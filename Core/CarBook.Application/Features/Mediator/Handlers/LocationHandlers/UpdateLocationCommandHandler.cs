using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers;


public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
{
    private readonly IRepository<Location> _featureRepository;
    
    public UpdateLocationCommandHandler(IRepository<Location> featureRepository)
    {
        _featureRepository = featureRepository;
    }
    
    public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
      var location = await _featureRepository.GetByIdAsync(request.LocationId);
      location.Name = request.Name;
      await _featureRepository.UpdateAsync(location);
      
    }
}

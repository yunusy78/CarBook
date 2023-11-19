using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers;

public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand>
{
    private readonly IRepository<Location> _featureRepository;
    
    public DeleteLocationCommandHandler(IRepository<Location> featureRepository)
    {
        _featureRepository = featureRepository;
    }
    
    public async Task Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await _featureRepository.GetByIdAsync(request.LocationId);
       await _featureRepository.DeleteAsync(location);
    }
}
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.LocationResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers;

public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
{
    private readonly IRepository<Location> _featureRepository;
    
    public GetLocationByIdQueryHandler(IRepository<Location> featureRepository)
    {
        _featureRepository = featureRepository;
    }
    
    public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var feature = await _featureRepository.GetByIdAsync(request.LocationId);
        var result = new GetLocationByIdQueryResult
        {
            LocationId = feature.LocationId,
            Name = feature.Name
        };
        return result;
    }
}

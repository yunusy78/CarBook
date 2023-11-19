using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.LocationResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers;

public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
{
    private readonly IRepository<Location> _featureRepository;
    
    public GetLocationQueryHandler(IRepository<Location> featureRepository)
    {
        _featureRepository = featureRepository;
    }
    
    public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
    {
        var locations = await _featureRepository.ListAllAsync();
        var result = locations.Select(x => new GetLocationQueryResult
        {
            LocationId = x.LocationId,
            Name = x.Name
        }).ToList();
        return result;
    }
}
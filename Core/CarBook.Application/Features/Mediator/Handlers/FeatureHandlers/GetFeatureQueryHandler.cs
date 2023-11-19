using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;

public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
{
    private readonly IRepository<Feature> _featureRepository;
    
    public GetFeatureQueryHandler(IRepository<Feature> featureRepository)
    {
        _featureRepository = featureRepository;
    }
    
    public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
    {
        var features = await _featureRepository.ListAllAsync();
        var result = features.Select(x => new GetFeatureQueryResult
        {
            FeatureId = x.FeatureId,
            Name = x.Name
        }).ToList();
        return result;
    }
}
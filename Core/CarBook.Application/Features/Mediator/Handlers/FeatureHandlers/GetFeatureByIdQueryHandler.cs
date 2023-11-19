using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;

public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
{
    private readonly IRepository<Feature> _featureRepository;
    
    public GetFeatureByIdQueryHandler(IRepository<Feature> featureRepository)
    {
        _featureRepository = featureRepository;
    }
    
    public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
    {
        var feature = await _featureRepository.GetByIdAsync(request.FeatureId);
        var result = new GetFeatureByIdQueryResult
        {
            FeatureId = feature.FeatureId,
            Name = feature.Name
        };
        return result;
    }
}

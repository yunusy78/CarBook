using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.LocationResults;
using CarBook.Application.Features.Mediator.Results.PricingResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.PricingQueries;

public class GetPricingQuery : IRequest<List<GetPricingQueryResult>>
{
    
}
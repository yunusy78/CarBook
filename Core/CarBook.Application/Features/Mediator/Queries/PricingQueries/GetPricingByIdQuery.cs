using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.LocationResults;
using CarBook.Application.Features.Mediator.Results.PricingResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.PricingQueries;

public class GetPricingByIdQuery : IRequest<GetPricingByIdQueryResult>
{
    public GetPricingByIdQuery(int id)
    {
        PricingId = id;
    }

    public int PricingId { get; set; }
    

}
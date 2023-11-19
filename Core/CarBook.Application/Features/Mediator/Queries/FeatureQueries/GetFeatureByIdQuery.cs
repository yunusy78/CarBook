using CarBook.Application.Features.Mediator.Results.FeatureResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.FeatureQueries;

public class GetFeatureByIdQuery : IRequest<GetFeatureByIdQueryResult>
{
    public GetFeatureByIdQuery(int featureId)
    {
        FeatureId = featureId;
    }

    public int FeatureId { get; set; }
    

}
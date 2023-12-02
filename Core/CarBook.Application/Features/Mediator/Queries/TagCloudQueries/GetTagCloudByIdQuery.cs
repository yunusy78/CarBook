using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.FooterResults;
using CarBook.Application.Features.Mediator.Results.ServiceResults;
using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using CarBook.Application.Features.Mediator.Results.TestimonialResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.TagCloudQueries;

public class GetTagCloudByIdQuery : IRequest<GetTagCloudByIdQueryResult>
{
    
    public int TagCloudId { get; set; }

    
    public GetTagCloudByIdQuery(int tagCloudId)
    {
        TagCloudId = tagCloudId;
        
    }
    

}
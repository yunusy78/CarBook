using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.FooterResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.FooterQueries;

public class GetFooterByIdQuery : IRequest<GetFooterByIdQueryResult>
{
    public GetFooterByIdQuery(int id)
    {
       FooterId = id;
    }

    public int FooterId { get; set; }
    

}
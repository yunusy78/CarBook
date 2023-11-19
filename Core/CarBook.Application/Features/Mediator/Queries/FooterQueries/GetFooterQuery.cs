using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.FooterResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.FooterQueries;

public class GetFooterQuery : IRequest<List<GetFooterQueryResult>>
{
    
}
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.FooterResults;
using CarBook.Application.Features.Mediator.Results.ServiceResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.ServiceQueries;

public class GetServiceQuery : IRequest<List<GetServiceQueryResult>>
{
    
}
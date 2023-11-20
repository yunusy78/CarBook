using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.FooterResults;
using CarBook.Application.Features.Mediator.Results.ServiceResults;
using CarBook.Application.Features.Mediator.Results.SocialMediaResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;

public class GetSocialMediaQuery : IRequest<List<GetSocialMediaQueryResult>>
{
    
}
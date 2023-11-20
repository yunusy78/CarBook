using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.FooterResults;
using CarBook.Application.Features.Mediator.Results.BlogCategoryResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogCategoryQueries;

public class GetBlogCategoryQuery : IRequest<List<GetBlogCategoryQueryResult>>
{
    
}
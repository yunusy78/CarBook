using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.FooterResults;
using CarBook.Application.Features.Mediator.Results.ServiceResults;
using CarBook.Application.Features.Mediator.Results.BlogCategoryResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogCategoryQueries;

public class GetBlogCategoryByIdQuery : IRequest<GetBlogCategoryByIdQueryResult>
{
    public GetBlogCategoryByIdQuery(int id)
    {
        BlogCategoryId = id;
    }

    public int BlogCategoryId { get; set; }
    

}
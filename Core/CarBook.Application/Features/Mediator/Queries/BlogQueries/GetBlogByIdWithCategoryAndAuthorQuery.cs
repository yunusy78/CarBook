using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.FooterResults;
using CarBook.Application.Features.Mediator.Results.ServiceResults;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries;

public class GetBlogByIdWithCategoryAndAuthorQuery : IRequest<GetBlogByIdWithCategoryAndAuthorQueryResult>
{
    public GetBlogByIdWithCategoryAndAuthorQuery(int id)
    {
        BlogId = id;
    }

    public int BlogId { get; set; }
    

}
using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.TagCloudQueries;

public class GetTagCloudByBlogIdQuery : IRequest<List<GetTagCloudByBlogIdQueryResult>>
{
    public int BlogId { get; set; }
    
    public GetTagCloudByBlogIdQuery(int blogId)
    {
        BlogId = blogId;
    }
}
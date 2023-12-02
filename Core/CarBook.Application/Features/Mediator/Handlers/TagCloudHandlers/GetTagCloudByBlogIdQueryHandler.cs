using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using CarBook.Application.Interfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers;

public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
{
    private readonly ITagCloudRepository _repository;
    
    public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository repository)
    {
        _repository = repository;
    }
    
    public  Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
    {
        var tagCloud =  _repository.GetTagCloudByBlogId(request.BlogId);
        var result = new List<GetTagCloudByBlogIdQueryResult>();
        foreach (var tag in tagCloud)
        {
            result.Add(new GetTagCloudByBlogIdQueryResult
            {
                TagCloudId = tag.TagCloudId,
                Tag = tag.Tag,
                BlogId = tag.BlogId
            });
        }
        return Task.FromResult(result);
    }
}
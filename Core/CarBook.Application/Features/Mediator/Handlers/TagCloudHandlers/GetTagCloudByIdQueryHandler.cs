using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers;

public class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
{
    private readonly IRepository<TagCloud> _repository;
    
    public GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository)
    {
        _repository = repository;
    }
    
    public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
    {
        var tagCloud = await _repository.GetByIdAsync(request.TagCloudId);
        var result = new GetTagCloudByIdQueryResult
        {
            
            TagCloudId = tagCloud.TagCloudId,
            Tag = tagCloud.Tag,
            BlogId = tagCloud.BlogId
            
        };
        return result;
    }
}

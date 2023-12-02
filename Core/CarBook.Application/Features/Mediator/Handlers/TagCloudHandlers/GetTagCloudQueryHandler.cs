using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers;

public class GetTagCloudQueryHandler : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
{
    private readonly IRepository<TagCloud> _repository;
    
    public GetTagCloudQueryHandler(IRepository<TagCloud> repository)
    {
        _repository = repository;
    }
    
    public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
    {
        var tagClouds = await _repository.ListAllAsync();
        var result = tagClouds.Select(x => new GetTagCloudQueryResult
        {
            TagCloudId = x.TagCloudId,
            Tag = x.Tag,
            BlogId = x.BlogId
            
        }).ToList();
        return result;
    }
}
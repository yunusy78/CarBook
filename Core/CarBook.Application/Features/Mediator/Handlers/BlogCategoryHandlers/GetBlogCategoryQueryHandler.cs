using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Queries.BlogCategoryQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.BlogCategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogCategoryHandlers;

public class GetBlogCategoryQueryHandler : IRequestHandler<GetBlogCategoryQuery, List<GetBlogCategoryQueryResult>>
{
    private readonly IRepository<BlogCategory> _repository;
    
    public GetBlogCategoryQueryHandler(IRepository<BlogCategory> repository)
    {
        _repository = repository;
    }
    
    public async Task<List<GetBlogCategoryQueryResult>> Handle(GetBlogCategoryQuery request, CancellationToken cancellationToken)
    {
        var blogCategories = await _repository.ListAllAsync();
        var result = blogCategories.Select(x => new GetBlogCategoryQueryResult
        {
            BlogCategoryId = x.BlogCategoryId,
            Name = x.Name,
            Description = x.Description,
            
        }).ToList();
        return result;
    }
}
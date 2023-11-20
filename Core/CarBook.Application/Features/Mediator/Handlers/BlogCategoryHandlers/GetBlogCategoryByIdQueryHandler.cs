using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Queries.BlogCategoryQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.BlogCategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogCategoryHandlers;

public class GetBlogCategoryByIdQueryHandler : IRequestHandler<GetBlogCategoryByIdQuery, GetBlogCategoryByIdQueryResult>
{
    private readonly IRepository<BlogCategory> _repository;
    
    public GetBlogCategoryByIdQueryHandler(IRepository<BlogCategory> repository)
    {
        _repository = repository;
    }
    
    public async Task<GetBlogCategoryByIdQueryResult> Handle(GetBlogCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var blogCategory = await _repository.GetByIdAsync(request.BlogCategoryId);
        var result = new GetBlogCategoryByIdQueryResult
        {
            BlogCategoryId = blogCategory.BlogCategoryId,
            Name = blogCategory.Name,
            Description = blogCategory.Description,
            
        };
        return result;
    }
}

using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
{
    private readonly IRepository<Blog> _repository;
    
    public GetBlogQueryHandler(IRepository<Blog> repository)
    {
        _repository = repository;
    }
    
    public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
    {
        var blogs = await _repository.ListAllAsync();
        var result = blogs.Select(x => new GetBlogQueryResult
        {
            BlogId = x.BlogId,
            Title = x.Title,
            Description = x.Description,
            ImageUrl = x.ImageUrl,
            Content = x.Content,
            AuthorId = x.AuthorId,
            CategoryId = x.CategoryId,
            CoverImage = x.CoverImage,
            Created = x.Created,
            Updated = x.Updated,
        }).ToList();
        return result;
    }
}
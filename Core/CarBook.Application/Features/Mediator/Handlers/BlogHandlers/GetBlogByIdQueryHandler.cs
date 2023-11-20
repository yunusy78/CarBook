using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
{
    private readonly IRepository<Blog> _repository;
    
    public GetBlogByIdQueryHandler(IRepository<Blog> repository)
    {
        _repository = repository;
    }
    
    public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        var blog = await _repository.GetByIdAsync(request.BlogId);
        var result = new GetBlogByIdQueryResult
        {
            BlogId = blog.BlogId,
            Title = blog.Title,
            Created = blog.Created,
            Description = blog.Description,
            ImageUrl = blog.ImageUrl,
            Updated = blog.Updated,
            Content = blog.Content,
            AuthorId = blog.AuthorId,
            CategoryId = blog.CategoryId,
            CoverImage = blog.CoverImage
            
            
        };
        return result;
    }
}

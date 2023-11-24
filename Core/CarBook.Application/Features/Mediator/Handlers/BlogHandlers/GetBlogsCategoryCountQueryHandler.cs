using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class GetBlogsCategoryCountQueryHandler : IRequestHandler<GetBlogsCategoryCountQuery, List<GetBlogsCategoryCountQueryResult>>
{
    private readonly IBlogRepository _repository;
    
    public GetBlogsCategoryCountQueryHandler(IBlogRepository repository)
    {
        _repository = repository;
    }
    
    
    public Task<List<GetBlogsCategoryCountQueryResult>> Handle(GetBlogsCategoryCountQuery request, CancellationToken cancellationToken)
    {
        var blogs =   _repository.GetBlogCountByCategory();
        
        var blogsResults = blogs.Select(blog => new GetBlogsCategoryCountQueryResult()
        {
            CategoryName = blog.Key,
            Count = blog.Value
        }).ToList();
        
        return Task.FromResult(blogsResults);
        
    }
}
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class GetBlogWithCategoryAndAuthorQueryHandler : IRequestHandler<GetBlogWithCategoryAndAuthorQuery, List<GetBlogsWithCategoryAndAuthorQueryResult>>
{
    private readonly IBlogRepository _repository;
    
    public GetBlogWithCategoryAndAuthorQueryHandler(IBlogRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<GetBlogsWithCategoryAndAuthorQueryResult>> Handle(GetBlogWithCategoryAndAuthorQuery request, CancellationToken cancellationToken)
    {
        var blogs = await _repository.GetBlogsWithCategoryAndAuthorAsync();
        var result = blogs.Select(x => new GetBlogsWithCategoryAndAuthorQueryResult
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
            AuthorImageUrl = x.Author.ImageUrl,
            AuthorName = x.Author.FirstName + " " + x.Author.LastName,
            CategoryName = x.Category.Name
        }).ToList();
        
        return result;
    }
}
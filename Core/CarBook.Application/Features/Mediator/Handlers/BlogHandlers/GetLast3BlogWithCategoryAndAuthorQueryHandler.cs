using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class GetLast3BlogWithCategoryAndAuthorQueryHandler : IRequestHandler<GetLast3BlogWithCategoryAndAuthorQuery, List<GetLast3BlogsWithCategoryAndAuthorQueryResult>>
{
    private readonly IBlogRepository _repository;
    
    public GetLast3BlogWithCategoryAndAuthorQueryHandler(IBlogRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<GetLast3BlogsWithCategoryAndAuthorQueryResult>> Handle(GetLast3BlogWithCategoryAndAuthorQuery request, CancellationToken cancellationToken)
    {
        var blogs = await _repository.GetLast3BlogsWithCategoryAndAuthorAsync();
        var result = blogs.Select(x => new GetLast3BlogsWithCategoryAndAuthorQueryResult
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
            AuthorName = x.Author.FirstName + " " + x.Author.LastName,
            CategoryName = x.Category.Name
        }).ToList();
        
        return result;
    }
}
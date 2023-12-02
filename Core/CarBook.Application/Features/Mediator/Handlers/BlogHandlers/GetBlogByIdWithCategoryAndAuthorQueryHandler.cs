using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class GetBlogByIdWithCategoryAndAuthorQueryHandler : IRequestHandler<GetBlogByIdWithCategoryAndAuthorQuery, GetBlogByIdWithCategoryAndAuthorQueryResult>
{
    private readonly IBlogRepository _repository;
    
    public GetBlogByIdWithCategoryAndAuthorQueryHandler(IBlogRepository repository)
    {
        _repository = repository;
    }


    public async Task<GetBlogByIdWithCategoryAndAuthorQueryResult> Handle(GetBlogByIdWithCategoryAndAuthorQuery request, CancellationToken cancellationToken)
    {
        var blog = await _repository.GetByIdWithCategoryAndAuthorAsync(request.BlogId);
        var result = new GetBlogByIdWithCategoryAndAuthorQueryResult
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
            CoverImage = blog.CoverImage,
            AuthorName = blog.Author.FirstName + " " + blog.Author.LastName,
            AuthorImageUrl = blog.Author.ImageUrl,
            AuthorDescription = blog.Author.Description,
            CategoryName = blog.Category.Name
        };
        return result;

    }
}

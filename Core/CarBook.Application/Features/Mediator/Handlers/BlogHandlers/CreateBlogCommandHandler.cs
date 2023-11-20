using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
{
    private readonly IRepository<Blog> _repository;
    
    public CreateBlogCommandHandler(IRepository<Blog> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = new Blog
        {
            Title = request.Title,
            Description = request.Description,
            ImageUrl = request.ImageUrl,
            Created = DateTime.Now,
            Updated = DateTime.Now,
            Content = request.Content,
            AuthorId = request.AuthorId,
            CategoryId = request.CategoryId,
            CoverImage = request.CoverImage
           
        };
        await _repository.AddAsync(blog);
    }
}

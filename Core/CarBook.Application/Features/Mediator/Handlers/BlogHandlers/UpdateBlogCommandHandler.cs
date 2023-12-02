using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers;


public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
{
    private readonly IRepository<Blog> _repository;
    
    public UpdateBlogCommandHandler(IRepository<Blog> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = await _repository.GetByIdAsync(request.BlogId);
        blog.Title = request.Title;
        blog.Description = request.Description;
        blog.ImageUrl = request.ImageUrl;
        blog.Content = request.Content;
        blog.Updated = DateTime.Now;
        blog.AuthorId = request.AuthorId;
        blog.CategoryId = request.CategoryId;
        blog.CoverImage = request.CoverImage;
        blog.Created = request.Created;
      await _repository.UpdateAsync(blog);
    }
}

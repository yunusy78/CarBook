using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.BlogCategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogCategoryHandlers;

public class DeleteBlogCategoryCommandHandler : IRequestHandler<DeleteBlogCategoryCommand>
{
    private readonly IRepository<BlogCategory> _repository;
    
    public DeleteBlogCategoryCommandHandler(IRepository<BlogCategory> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(DeleteBlogCategoryCommand request, CancellationToken cancellationToken)
    {
        var blogCategory = await _repository.GetByIdAsync(request.BlogCategoryId);
       await _repository.DeleteAsync(blogCategory);
    }
}
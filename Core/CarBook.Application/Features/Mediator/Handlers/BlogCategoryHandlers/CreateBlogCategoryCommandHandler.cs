using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.BlogCategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogCategoryHandlers;

public class CreateBlogCategoryCommandHandler : IRequestHandler<CreateBlogCategoryCommand>
{
    private readonly IRepository<BlogCategory> _repository;
    
    public CreateBlogCategoryCommandHandler(IRepository<BlogCategory> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(CreateBlogCategoryCommand request, CancellationToken cancellationToken)
    {
        var blogCategory = new BlogCategory
        {
            Name = request.Name,
            Description = request.Description,
            
        };
        await _repository.AddAsync(blogCategory);
    }
}

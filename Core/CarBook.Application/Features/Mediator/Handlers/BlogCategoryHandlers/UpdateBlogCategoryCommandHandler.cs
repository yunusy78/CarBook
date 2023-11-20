using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.BlogCategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogCategoryHandlers;


public class UpdateBlogCategoryCommandHandler : IRequestHandler<UpdateBlogCategoryCommand>
{
    private readonly IRepository<BlogCategory> _repository;
    
    public UpdateBlogCategoryCommandHandler(IRepository<BlogCategory> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(UpdateBlogCategoryCommand request, CancellationToken cancellationToken)
    {
      var blogCategory = await _repository.GetByIdAsync(request.BlogCategoryId);
        blogCategory.Name = request.Name;
      blogCategory.Description = request.Description;
      await _repository.UpdateAsync(blogCategory);
    }
}

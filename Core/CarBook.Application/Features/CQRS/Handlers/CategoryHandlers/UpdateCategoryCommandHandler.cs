using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers;

public class UpdateCategoryCommandHandler
{
    private readonly IRepository<Category> _repository;
    
    public UpdateCategoryCommandHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(UpdateCategoryCommand request)
    {
        var category = await _repository.GetByIdAsync(request.CategoryId);
        
        category.Name = request.Name;
        
        await _repository.UpdateAsync(category);
    }
}
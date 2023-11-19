using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers;

public class DeleteCategoryCommandHandler
{
    private readonly IRepository<Category> _repository;
    
    
    public DeleteCategoryCommandHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(DeleteCategoryCommand request)
    {
        var Category = await _repository.GetByIdAsync(request.CategoryId);
        
        await _repository.DeleteAsync(Category);
    }
}
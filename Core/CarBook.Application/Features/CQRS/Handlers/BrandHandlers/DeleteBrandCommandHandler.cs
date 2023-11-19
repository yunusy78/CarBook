using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers;

public class DeleteBrandCommandHandler
{
    private readonly IRepository<Brand> _repository;
    
    
    public DeleteBrandCommandHandler(IRepository<Brand> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(DeleteBrandCommand request)
    {
        var brand = await _repository.GetByIdAsync(request.BrandId);
        
        await _repository.DeleteAsync(brand);
    }
}
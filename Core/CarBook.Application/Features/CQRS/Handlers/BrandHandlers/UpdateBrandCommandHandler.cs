using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers;

public class UpdateBrandCommandHandler
{
    private readonly IRepository<Brand> _repository;
    
    public UpdateBrandCommandHandler(IRepository<Brand> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(UpdateBrandCommand request)
    {
        var brand = await _repository.GetByIdAsync(request.BrandId);
        
        brand.BrandName = request.BrandName;
        
        await _repository.UpdateAsync(brand);
    }
}
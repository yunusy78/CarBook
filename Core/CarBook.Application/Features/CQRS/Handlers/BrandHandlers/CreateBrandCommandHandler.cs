using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers;

public class CreateBrandCommandHandler
{
    private readonly IRepository<Brand> _repository;
    
    public CreateBrandCommandHandler(IRepository<Brand> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(CreateBrandCommand request)
    {
        var brand = new Brand
        {
            BrandName = request.BrandName
        };
        
        await _repository.AddAsync(brand);
    }
    
}
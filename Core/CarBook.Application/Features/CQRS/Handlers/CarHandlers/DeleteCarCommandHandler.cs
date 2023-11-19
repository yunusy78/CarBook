using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class DeleteCarCommandHandler
{
    private readonly IRepository<Car> _repository;
    
    
    public DeleteCarCommandHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(DeleteCarCommand request)
    {
        var car = await _repository.GetByIdAsync(request.CarId);
        
        await _repository.DeleteAsync(car);
    }
}
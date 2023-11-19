using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class CreateCarCommandHandler
{
    private readonly IRepository<Car> _repository;
    
    public CreateCarCommandHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(CreateCarCommand request)
    {
        var car = new Car
        {
            BrandId = request.BrandId,
            Model = request.Model,
            Year = request.Year,
            Price = request.Price,
            Color = request.Color,
            Mileage = request.Mileage,
            Fuel = request.Fuel,
            LocationId = request.LocationId,
            Seats = request.Seats,
            IsAvailable = request.IsAvailable,
            Transmission = request.Transmission,
            Luggage = request.Luggage,
            Doors = request.Doors,
            ImageUrl = request.ImageUrl
        };
        
        await _repository.AddAsync(car);
    }
    
}
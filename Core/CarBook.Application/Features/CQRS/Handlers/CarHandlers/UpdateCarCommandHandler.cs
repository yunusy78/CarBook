using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class UpdateCarCommandHandler
{
    private readonly IRepository<Car> _repository;
    
    public UpdateCarCommandHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(UpdateCarCommand request)
    {
        var car = await _repository.GetByIdAsync(request.CarId);
        
        car.BrandId = request.BrandId;
        car.Model = request.Model;
        car.Year = request.Year;
        car.Price = request.Price;
        car.Color = request.Color;
        car.Mileage = request.Mileage;
        car.Fuel = request.Fuel;
        car.LocationId = request.LocationId;
        car.Seats = request.Seats;
        car.IsAvailable = request.IsAvailable;
        car.Doors = request.Doors;
        car.Luggage = request.Luggage;
        car.Transmission = request.Transmission;
        car.ImageUrl = request.ImageUrl;
        car.CategoryId = request.CategoryId;
        await _repository.UpdateAsync(car);
    }
}
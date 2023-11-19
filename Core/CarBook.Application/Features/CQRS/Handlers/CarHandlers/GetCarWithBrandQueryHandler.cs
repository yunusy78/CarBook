using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarWithBrandQueryHandler
{
    private readonly ICarRepository _repository;
    
    public GetCarWithBrandQueryHandler(ICarRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<GetCarWithBrandQueryResult>> Handle()
    {
        var cars = await _repository.GetCarsAsync();
        
        var carsResults = cars.Select(car => new GetCarWithBrandQueryResult()
        {
            CarId = car.CarId,
            BrandId = car.BrandId,
            BrandName = car.Brand.BrandName,
            Model = car.Model,
            Year = car.Year,
            Price = car.Price,
            Color = car.Color,
            Mileage = car.Mileage,
            Fuel = car.Fuel,
            LocationId = car.LocationId,
            Seats = car.Seats,
            IsAvailable = car.IsAvailable,
            Doors = car.Doors,
            Luggage = car.Luggage,
            Transmission = car.Transmission,
            ImageUrl = car.ImageUrl
            
        }).ToList();
        
        return carsResults;
    }
}
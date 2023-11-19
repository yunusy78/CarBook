using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarByIdQueryHandler
{
    private readonly IRepository<Car> _repository;
    
    public GetCarByIdQueryHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }
    
    public async Task<GetCarByIdQueryResult> Handle(int id)
    {
      var car=  await _repository.GetByIdAsync(id);
        
        var carDto = new GetCarByIdQueryResult()
        {
            CarId = car.CarId,
            BrandId = car.BrandId,
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
            
        };
        
        return carDto;
    }
}
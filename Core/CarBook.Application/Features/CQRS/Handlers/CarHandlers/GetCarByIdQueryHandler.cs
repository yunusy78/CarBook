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
    private readonly ICarRepository _carRepository;
    
    public GetCarByIdQueryHandler(IRepository<Car> repository, ICarRepository carRepository)
    {
        _repository = repository;
        _carRepository = carRepository;
    }
    
    public async Task<GetCarByIdQueryResult> Handle(int id)
    {
      var car=  await _carRepository.GetByIdAsyncWithBrand(id);
        
        var carDto = new GetCarByIdQueryResult()
        {
            CarId = car.CarId,
            BrandId = car.BrandId,
            Model = car.Model,
            BrandName = car.Brand.BrandName,
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
            ImageUrl = car.ImageUrl,
            CategoryId = car.CategoryId
            
        };
        
        return carDto;
    }
}
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarWithPricingWithQueryHandler
{
    private readonly ICarRepository _repository;
    
    public GetCarWithPricingWithQueryHandler(ICarRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<GetCarWithPricingQueryResult>> Handle()
    {
        var cars = await _repository.GetCarWithPriceAsync();

        var carsResults = cars.Select(car => new GetCarWithPricingQueryResult()
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
            ImageUrl = car.ImageUrl,
            CategoryId = car.CategoryId,
            CategoryName = car.Category.Name,
            PricingNames = car.CarPricings.Select(x=>x.Pricing.Name).ToList(),
            PricingAmounts = car.CarPricings.Select(x=>x.Price).ToList(),
            PricingData = car.CarPricings.ToDictionary(x=>x.Pricing.Name, x=>x.Price)

        }).ToList();

        return carsResults;
    }

    
    
    
    
    
    
}
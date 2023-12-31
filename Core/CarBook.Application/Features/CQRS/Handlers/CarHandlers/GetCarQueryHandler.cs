﻿using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarQueryHandler
{
    private readonly IRepository<Car> _repository;
    
    public GetCarQueryHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }
    
    public async Task<List<GetCarQueryResult>> Handle()
    {
        var cars = await _repository.ListAllAsync();
        
        var carsResults = cars.Select(car => new GetCarQueryResult()
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
            ImageUrl = car.ImageUrl,
            CategoryId = car.CategoryId
            
        }).ToList();
        
        return carsResults;
    }
    
}
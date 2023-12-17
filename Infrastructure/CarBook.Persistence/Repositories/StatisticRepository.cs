using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories;

public class StatisticRepository : IStatisticRepository
{
    private readonly CarBookDbContext _context;
    
    public StatisticRepository(CarBookDbContext context)
    {
        _context = context;
    }
    
    public  int GetCarCount()
    {
        var carCount = _context.Cars.Count();
        return carCount;
    }

    public int GetBrandCount()
    {
        var brandCount = _context.Brands.Count();
        return brandCount;
    }

    public int GetBlogCount()
    {
        var blogCount = _context.Blogs.Count();
        return blogCount;
    }

    public int GetAuthorCount()
    {
        var authorCount = _context.Authors.Count();
        return authorCount;
    }

    public string GetHighestPriceCar()
    {
        var highestPriceCar = _context.Cars.
            Include(x=>x.CarPricings).
            OrderByDescending(x => x.Price).FirstOrDefault();
        return highestPriceCar!.Model;
    }

    public string GetLowestPriceCar()
    {
        var lowestPriceCar = _context.Cars.
            Include(x=>x.CarPricings).
            OrderBy(x => x.Price).FirstOrDefault();
        return lowestPriceCar!.Model;
    }

    public string GetMostRentedCarModel()
    {
        var mostRentedCar = _context.ReservationCars.
            Include(x=>x.Car).
            GroupBy(x => x.Car.Model).
            OrderByDescending(x => x.Count()).
            Select(x => x.Key).FirstOrDefault();
        return mostRentedCar!;
    }

    public string GetMinRentedCarModel()
    {
        var minRentedCar = _context.ReservationCars.
            Include(x=>x.Car).
            GroupBy(x => x.Car.Model).
            OrderBy(x => x.Count()).
            Select(x => x.Key).FirstOrDefault();
        return minRentedCar!;
    }
}
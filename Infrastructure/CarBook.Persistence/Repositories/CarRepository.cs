using System.Linq.Expressions;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories;

public class CarRepository : ICarRepository
{
    private readonly CarBookDbContext _context;

    public CarRepository(CarBookDbContext context)
    {
        _context = context;
    }

    public async Task<List<Car>> GetCarsAsync()
    {
        var cars = await _context.Cars
            .Include(x=>x.Brand)
            .Include(y=>y.Category)
            .ToListAsync();
        return cars;
    }

    public async Task<List<Car>> GetCarWithPriceAsync()
    {
        var cars = await _context.Cars
            .Include(x => x.Brand)
            .Include(y => y.Category)
            .Include(z => z.CarPricings)
            .ThenInclude(f => f.Pricing)
            .ToListAsync();

        return cars;
    }

    public Task<Car> GetByIdAsyncWithBrand(int id)
    {
        var car = _context.Cars
            .Include(x => x.Brand)
            .Include(y => y.Category)
            .FirstOrDefaultAsync(x => x.CarId == id);
        return car!;
    }

    public Dictionary<string, int> GetCarCountByCategory()
    {
        var cars = _context.Cars.Include(x => x.Category).ToList();
        var carCountByCategory = cars.GroupBy(x => x.Category.Name)
            .ToDictionary(x => x.Key, y => y.Count());
        return carCountByCategory;
    }

    public async Task<List<Car>> GetByFilterAsync(Expression<Func<Car, bool>> filter)
    {
        var result = await _context.Cars.Where(filter)
            .Include(x => x.Brand)
            .Include(y => y.Category)
            .Include(z => z.CarPricings)
            .ThenInclude(f => f.Pricing)
            .ToListAsync();
        return result;
    }

}
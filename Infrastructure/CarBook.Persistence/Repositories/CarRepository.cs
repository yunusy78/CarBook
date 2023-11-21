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
        var cars = await _context.Cars.Include(x=>x.Brand).Include(y=>y.Category).ToListAsync();
        return cars;
    }
}
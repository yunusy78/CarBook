using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces;

public interface ICarRepository
{
    Task<List<Car>> GetCarsAsync();
    
}
﻿using System.Linq.Expressions;
using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces;

public interface ICarRepository
{
    Task<List<Car>> GetCarsAsync();
    
    Task<List<Car>> GetCarWithPriceAsync();
    
    Task<Car> GetByIdAsyncWithBrand(int id);
    
    Dictionary<string, int> GetCarCountByCategory();
    
    Task<List<Car>>GetByFilterAsync(Expression<Func<Car, bool>> filter);
    
}
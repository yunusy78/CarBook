using System.Linq.Expressions;
using CarBook.Application.Interfaces;
using CarBook.Domain.DTOs.CarFeatureDto;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories;

public class CarFeatureRepository : ICarFeatureRepository
{
    private readonly CarBookDbContext _dbContext;
    
    
    public CarFeatureRepository(CarBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<CarFeature>> GetAllAsync()
    {
        var carFeatures = await _dbContext.CarFeatures.ToListAsync();
        return carFeatures;
    }

    public async Task<CarFeature> GetByIdAsync(int id)
    {
        var carFeature = await _dbContext.CarFeatures.FindAsync(id);
        return carFeature!;
        
    }

    public Task AddAsync(CarFeature entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(CarFeature entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(CarFeature entity)
    {
        var carFeature = await _dbContext.CarFeatures.FindAsync(entity.CarId);
        _dbContext.CarFeatures.Remove(carFeature!);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task CreateCarPricingAsync(CreateCarFeatureDto carPricingDto)
    {
        var carFeature = new CarFeature
        {
            CarId = carPricingDto.CarId,
            FeatureId = carPricingDto.FeatureId,
            IsAvailable = carPricingDto.IsAvailable
        };
        await _dbContext.CarFeatures.AddAsync(carFeature);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateCarPricingAsync(UpdateCarFetaureDto carPricingDto)
    {
        var carFeature = await _dbContext.CarFeatures.FindAsync(carPricingDto.CarFeatureId);
        carFeature!.CarId = carPricingDto.CarId;
        carFeature.FeatureId = carPricingDto.FeatureId;
        carFeature.IsAvailable = carPricingDto.IsAvailable;
        _dbContext.CarFeatures.Update(carFeature);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task<List<GetCarFeatureWithCarDto>> GetCarFeatureWithCarAndFeatureAsync()
    {
        var carFeatures = await _dbContext.CarFeatures
            .Include(x => x.Car)
            .Include(x => x.Feature)
            .ToListAsync();
        
        var carFeatureList = new List<GetCarFeatureWithCarDto>();
        foreach (var carFeature in carFeatures)
        {
            var carFeatureWithCarAndFeature = new GetCarFeatureWithCarDto
            {
                CarFeatureId = carFeature.CarFeatureId,
                CarId = carFeature.CarId,
                FeatureId = carFeature.FeatureId,
                IsAvailable = carFeature.IsAvailable,
                CarModel = carFeature.Car.Model,
                FeatureName = carFeature.Feature.Name
            };
            carFeatureList.Add(carFeatureWithCarAndFeature);
        }
        return carFeatureList;
    }

    public async Task<List<GetCarFeatureWithCarDto>> GetByFilterAsync(int id)
    {
        var carFeatures = await _dbContext.CarFeatures
            .Where(x=>x.CarId==id)
            .Include(x => x.Car)
            .Include(x => x.Feature)
            .ToListAsync();
        
        var carFeatureList = new List<GetCarFeatureWithCarDto>();
        foreach (var carFeature in carFeatures)
        {
            var carFeatureWithCarAndFeature = new GetCarFeatureWithCarDto
            {
                CarFeatureId = carFeature.CarFeatureId,
                CarId = carFeature.CarId,
                FeatureId = carFeature.FeatureId,
                IsAvailable = carFeature.IsAvailable,
                CarModel = carFeature.Car.Model,
                FeatureName = carFeature.Feature.Name
            };
            carFeatureList.Add(carFeatureWithCarAndFeature);
        }
        return carFeatureList;
        
    }
    
}
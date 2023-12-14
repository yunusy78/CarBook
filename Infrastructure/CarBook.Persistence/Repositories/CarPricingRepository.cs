using AutoMapper;
using CarBook.Application.Interfaces;
using CarBook.Domain.DTOs.CarPricingDto;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories;

public class CarPricingRepository : ICarPricingRepository
{
    private readonly CarBookDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public CarPricingRepository(CarBookDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<List<CarPricingDto>> GetAllAsync()
    {
        var results = await _dbContext.CarPricings
            .Include(x => x.Car)
            .Include(x => x.Pricing)
            .ToListAsync();

        // Assuming you have a mapping from CarPricing to CarPricingDto
        var carPricingDtos = _mapper.Map<List<CarPricingDto>>(results);

        return carPricingDtos;
    }


    public async Task<CarPricingDto> GetByIdAsync(int id)
    {
        var result = await _dbContext.CarPricings
            .Include(x => x.Car)
            .Include(x => x.Pricing)
            .FirstOrDefaultAsync(x => x.CarPricingId == id);
        var carPricingDto = _mapper.Map<CarPricingDto>(result);
        return carPricingDto;
    }

    public  Task AddAsync(CarPricingDto entity)
    {
        throw new NotImplementedException();
    }

    public  Task UpdateAsync(CarPricingDto entity)
    {
        throw new NotImplementedException();
        
    }

    public async Task DeleteAsync(CarPricingDto entity)
    {
        var existingEntity = await _dbContext.CarPricings.FindAsync(entity.CarPricingId);

        if (existingEntity != null)
        {
            _dbContext.Entry(existingEntity).State = EntityState.Detached; // Detach the entity
            _dbContext.CarPricings.Remove(existingEntity); // Now, remove it
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task CreateCarPricingAsync(CreateCarPricingDto carPricingDto )
    {
        var carPricing = _mapper.Map<CarPricing>(carPricingDto);
        
        await _dbContext.CarPricings.AddAsync(carPricing);
        await _dbContext.SaveChangesAsync();
       
    }

    public async Task UpdateCarPricingAsync(UpdateCarPricingDto carPricingDto)
    {
        var carPricing = _mapper.Map<CarPricing>(carPricingDto);
        _dbContext.CarPricings.Update(carPricing);
        await _dbContext.SaveChangesAsync();
    }
    
}
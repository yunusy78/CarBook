using System.Linq.Expressions;
using AutoMapper;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Dto.Dtos.ReservationDto;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories;

public class ReservationCarRepository : IReservationCarRepository
{
    private readonly CarBookDbContext _context;
    private readonly IMapper _mapper;
    
    public ReservationCarRepository(CarBookDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task CreateReservationAsync(CreateReservationDto dto)
    {
        var reservation = new CreateReservationDto()
        {
            CarId = dto.CarId,
            DropOffDate = dto.DropOffDate,
            PickUpDate = dto.PickUpDate,
            PickUpTime = dto.PickUpTime,
            DropOffTime = dto.DropOffTime,
            PickUpDescription = dto.PickUpDescription,
            DropOffDescription = dto.DropOffDescription,
            PickUpLocationId = dto.PickUpLocationId,
            DropOffLocationId = dto.DropOffLocationId,
            CustomerId = dto.CustomerId,
            TotalDays = dto.TotalDays,
            TotalPrice = dto.TotalPrice,
        };
        var result =_mapper.Map<ReservationCar>(reservation);
        _context.ReservationCars.Add(result);
        await _context.SaveChangesAsync();
        
    }

    public async Task UpdateReservationAsync(UpdateReservationDto dto)
    {
        var reservation = new UpdateReservationDto()
        {
            ReservationCarId = dto.ReservationCarId,
            CarId = dto.CarId,
            DropOffDate = dto.DropOffDate,
            PickUpDate = dto.PickUpDate,
            PickUpTime = dto.PickUpTime,
            DropOffTime = dto.DropOffTime,
            PickUpDescription = dto.PickUpDescription,
            DropOffDescription = dto.DropOffDescription,
            PickUpLocationId = dto.PickUpLocationId,
            DropOffLocationId = dto.DropOffLocationId,
            CustomerId = dto.CustomerId,
            TotalDays = dto.TotalDays,
            TotalPrice = dto.TotalPrice,
        };
        var result = _mapper.Map<ReservationCar>(reservation);
        _context.ReservationCars.Update(result);
           await _context.SaveChangesAsync();
           
    }

    public async Task<List<ReservationCar>> GetReservationCarWithCarAndLocationAndStatusAndPricingAsync()
    {
        var result = await _context.ReservationCars
            .Include(x => x.Car)
            .Include(y => y.Customer)
            .Include(z => z.Car.Brand)
            .Include(z => z.Car.CarPricings)
            .ThenInclude(f => f.Pricing)
            .Include(z => z.Car.Category)
            .Include(z => z.Car.Location)
            .ToListAsync();
        
        return result;
    }

    public async Task<List<ReservationCar>> GetByFilterAsync(Expression<Func<ReservationCar, bool>> filter)
    {
        var result = await _context.ReservationCars.Where(filter)
            .Include(x => x.Car)
            .Include(y => y.Customer)
            .Include(z => z.Car.Brand)
            .Include(z => z.Car.CarPricings)
            .ThenInclude(f => f.Pricing)
            .Include(z => z.Car.Category)
            .Include(z => z.Car.Location)
            .ToListAsync();
        return result;
    }

    public async Task<List<ReservationCar>> GetAllAsync()
    {
        var result = await _context.ReservationCars
            .Include(x => x.Car)
            .ToListAsync();
        return result;
    }

    public async Task<ReservationCar> GetByIdAsync(int id)
    {
        var result = await _context.ReservationCars.FirstOrDefaultAsync(x => x.ReservationCarId == id);
        return result;
    }

    public Task AddAsync(ReservationCar entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(ReservationCar entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(ReservationCar entity)
    {
         _context.ReservationCars.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
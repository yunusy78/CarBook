using System.Linq.Expressions;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using CarBook.Dto.Dtos.ReservationDto;

namespace CarBook.Application.Interfaces;

public interface IReservationCarRepository : IGenericRepository<ReservationCar>
{
    
    Task CreateReservationAsync(CreateReservationDto dto);
    Task UpdateReservationAsync(UpdateReservationDto dto);
    Task <List <ReservationCar>> GetReservationCarWithCarAndLocationAndStatusAndPricingAsync();
    Task<List<ReservationCar>>  GetByFilterAsync(Expression<Func<ReservationCar, bool>> filter);
    
}
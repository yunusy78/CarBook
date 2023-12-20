using System.Linq.Expressions;
using CarBook.Dto.Dtos.ReservationDto;

namespace Business.Abstract;

public interface IReservationService : IGenericService<GetReservationCarDto>
{
    
    public Task<bool> CreateReservationAsync(CreateReservationDto dto, string accessToken);
    Task <bool> UpdateReservationAsync(UpdateReservationDto dto);
    Task <List <GetReservationCarDto>> GetReservationCarWithCarAndLocationAndStatusAndPricingAsync();
    Task<List<GetReservationCarDto>>  GetByFilterAsync(Expression<Func<GetReservationCarDto, bool>> filter);
    
}
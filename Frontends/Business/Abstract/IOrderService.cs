using CarBook.Dto.Dtos.Order;

namespace Business.Abstract;

public interface IOrderService : IGenericService<OrderDto>
{
    
    Task<ResponseDto> Checkout(StripeRequestDto stripeRequestDto, string accessToken);
    Task<ResponseDto> Confirmation(int orderId);
    
}
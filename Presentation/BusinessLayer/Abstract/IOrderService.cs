using CarBook.Domain.Entities;

namespace BusinessLayer.Abstract;

public interface IOrderService : IGenericService<Order>
{
    void UpdateStripePaymentId(int id, string sessionId, string paymentIntentId);
    void UpdateStripeSessionId(int id, string sessionId);
    
    
}
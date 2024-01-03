using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces;

public interface IOrderRepository : IGenericRepository<Order>
{
    void UpdateStripePaymentId(int id, string sessionId, string paymentIntentId);
    void UpdateStripeSessionId(int id, string sessionId);
    
}
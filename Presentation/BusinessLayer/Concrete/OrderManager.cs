using System.Linq.Expressions;
using BusinessLayer.Abstract;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace BusinessLayer.Concrete;

public class OrderManager : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    
    public OrderManager(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public async Task<Order> GetByIdAsync(int id)
    {
        var result = await _orderRepository.GetByIdAsync(id);
        return result;
    }

    public async Task<List<Order>> GetAllAsync()
    {
        var result = await _orderRepository.GetAllAsync();
        return result;
    }

    public async Task AddAsync(Order entity)
    {
       await _orderRepository.AddAsync(entity);
        
    }

    public async Task UpdateAsync(Order entity)
    {
        await _orderRepository.UpdateAsync(entity);
    }

    public async Task RemoveAsync(Order entity)
    {
        await _orderRepository.DeleteAsync(entity);
    }

    public Task RemoveRangeAsync(List<Order> entities)
    {
        throw new NotImplementedException();
    }

    public Task<Order> FindAsync(Expression<Func<Order, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public void UpdateStripePaymentId(int id, string sessionId, string paymentIntentId)
    {
         _orderRepository.UpdateStripePaymentId(id, sessionId, paymentIntentId);
    }

    public void UpdateStripeSessionId(int id, string sessionId)
    {
        _orderRepository.UpdateStripeSessionId(id, sessionId);
    }
}
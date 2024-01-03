using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    
    private readonly CarBookDbContext _context;
    
    public OrderRepository(CarBookDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Order>> GetAllAsync()
    {
        var result = await _context.Orders.ToListAsync();
        return result;
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        var result = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }

    public async Task AddAsync(Order entity)
    {
        var result = await _context.Orders.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order entity)
    {
        var result =   _context.Orders.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Order entity)
    {
        var result = _context.Orders.Remove(entity);
        await _context.SaveChangesAsync();
    }
    
    
    public void UpdateStripePaymentId(int id, string sessionId, string paymentIntentId)
    {
        var orderFromDb = _context.Orders.FirstOrDefault(u => u.Id == id);
        orderFromDb!.PaymentDate = DateTime.Now;
        orderFromDb.SessionId = sessionId;
        orderFromDb.PaymentIntentId = paymentIntentId;
        _context.SaveChangesAsync();
    }

    public void UpdateStripeSessionId(int id, string sessionId)
    {
        var order = _context.Orders.FirstOrDefault(u => u.Id == id);
        order!.PaymentDate = DateTime.Now;
        order.SessionId = sessionId;
        order.PaymentIntentId=sessionId;
        _context.SaveChangesAsync();
    }
}
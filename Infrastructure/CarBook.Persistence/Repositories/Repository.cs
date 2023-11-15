using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories;

public class Repository<T>: IRepository<T> where T : class
{ 
    private readonly CarBookDbContext _dbContext;
    
    public Repository(CarBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<T> GetByIdAsync(int id)
    {
        var result = await _dbContext.Set<T>().FindAsync(id);
        return result!;
        
    }

    public async Task<List<T>> ListAllAsync()
    {
        var result = await _dbContext.Set<T>().ToListAsync();
        return result;
    }

    public async Task AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}
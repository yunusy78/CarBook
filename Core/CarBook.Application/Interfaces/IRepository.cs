namespace CarBook.Application.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<List<T>> ListAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    
    
}
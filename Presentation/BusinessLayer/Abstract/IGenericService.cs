using System.Linq.Expressions;

namespace BusinessLayer.Abstract;

public interface IGenericService<T> where T : class, new()
{

    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
    Task RemoveRangeAsync(List<T> entities);
    Task<T> FindAsync(Expression<Func<T, bool>> predicate);

}
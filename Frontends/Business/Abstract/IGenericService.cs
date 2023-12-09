using System.Linq.Expressions;

namespace Business.Abstract;

public interface IGenericService<T> where T : class
{
    Task<bool> DeleteAsync(int id);
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetListByFilterAsync(Expression<Func<T, bool>> filter);
    
    
    
}
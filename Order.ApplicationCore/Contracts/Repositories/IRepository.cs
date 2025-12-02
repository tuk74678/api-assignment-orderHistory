using System.Linq.Expressions;

namespace Order.ApplicationCore.Contracts.Repositories;

public interface IRepository<T> where T : class
{
    Task<T> InsertAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
}
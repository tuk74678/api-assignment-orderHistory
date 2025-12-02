namespace Order.ApplicationCore.Contracts.Repositories;

public interface IRepository<T> where T : class
{
    Task<T> Insert(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
}
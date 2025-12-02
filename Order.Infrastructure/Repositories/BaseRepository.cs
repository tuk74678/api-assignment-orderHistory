using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Repositories;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repositories;

public class BaseRepository<T>: IRepository<T> where T : class
{
    protected readonly OrderHistoryDbContext _orderHistoryDbContext;
    public BaseRepository(OrderHistoryDbContext orderHistoryDbContext)
    {
        _orderHistoryDbContext = orderHistoryDbContext;
    }
    public async Task<T> InsertAsync(T entity)
    {
        await _orderHistoryDbContext.Set<T>().AddAsync(entity);
        await _orderHistoryDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _orderHistoryDbContext.Entry(entity).State = EntityState.Modified;
        await _orderHistoryDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<T> DeleteAsync(int id)
    {
        var entity = _orderHistoryDbContext.Set<T>().Find(id);
        if (entity != null)
        {
            _orderHistoryDbContext.Set<T>().Remove(entity);
            await _orderHistoryDbContext.SaveChangesAsync();
            return entity;
        }
        return null;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _orderHistoryDbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _orderHistoryDbContext.Set<T>();
        // Include navigation properties
        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
    }
    
}
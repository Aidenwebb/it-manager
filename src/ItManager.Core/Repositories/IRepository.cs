using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ItManager.Core.Repositories;

public interface IRepository<TEntity, TIdType>
    where TEntity: class
    where TIdType:  IEquatable<TIdType>
{
    ValueTask<TEntity?> GetByIdAsync(TIdType id);
    Task<List<TEntity>> GetAllAsync();
    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}
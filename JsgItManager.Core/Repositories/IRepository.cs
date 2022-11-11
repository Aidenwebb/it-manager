using System.Linq.Expressions;

namespace JsgItManager.Core.Repositories;

public interface IRepository<TEntity, TIdType>
    where TEntity: class
    where TIdType:  IEquatable<TIdType>
{
    ValueTask<TEntity> GetByIdAsync(TIdType id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}
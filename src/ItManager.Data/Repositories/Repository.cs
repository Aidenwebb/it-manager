using System.Linq.Expressions;
using ItManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ItManager.Data.Repositories;

public class Repository<TEntity, TIdType> : IRepository<TEntity, TIdType>
    where TEntity : class
    where TIdType : IEquatable<TIdType>

{
    protected readonly JsgItManagerDbContext Context;
    
    public Repository(JsgItManagerDbContext context)
    {
        Context = context;
    }

    public ValueTask<TEntity?> GetByIdAsync(TIdType id)
    {
        return Context.Set<TEntity>().FindAsync(id);
    }

    public Task<List<TEntity>> GetAllAsync()
    {
        return Context.Set<TEntity>().ToListAsync();
    }

    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().Where(predicate);
    }

    public Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
    }

    public ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity)
    {
        return Context.Set<TEntity>().AddAsync(entity);
    }

    public Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        return Context.Set<TEntity>().AddRangeAsync(entities);
    }

    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        Context.Set<TEntity>().RemoveRange(entities);
    }
}
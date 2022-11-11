using System.Linq.Expressions;
using JsgItManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JsgItManager.Data.Repositories;

public class Repository<TEntity, TIdType> : IRepository<TEntity, TIdType>
    where TEntity : class
    where TIdType : IEquatable<TIdType>

{
    protected readonly DbContext Context;
    
    public Repository(DbContext context)
    {
        Context = context;
    }

    public ValueTask<TEntity> GetByIdAsync(TIdType id)
    {
        return Context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().Where(predicate);
    }

    public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().SingleOrDefault(predicate);
    }

    public async Task AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await Context.Set<TEntity>().AddRangeAsync(entities);
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
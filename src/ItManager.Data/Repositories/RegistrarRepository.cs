using ItManager.Core.Models;
using ItManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ItManager.Data.Repositories;

/// <summary>
/// The default implementation of the <see cref="IRegistrarRepository"/> interface.
/// </summary>
public class RegistrarRepository : Repository<Registrar, Guid>, IRegistrarRepository
{
    /// <summary>
    /// Initializes a new instance of this <see cref="RegistrarRepository"/> instance that uses the provided <paramref name="context"/> as data store.
    /// </summary>
    /// <param name="context">The database context to use.</param>
    public RegistrarRepository(JsgItManagerDbContext context) : base(context)
    {
    }

    /// <inheritdoc/>
    public Task EnsureDomainsAreLoadedAsync(Registrar registrar)
    {
        return Context.Entry(registrar).Collection(r => r.Domains).LoadAsync();
    }

    /// <inheritdoc/>
    public Task<List<Registrar>> GetAllWithDomainsAsync()
    {
        return Context.Registrars.Include(r => r.Domains).ToListAsync();
    }
}

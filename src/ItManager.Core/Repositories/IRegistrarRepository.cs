using ItManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItManager.Core.Repositories;

/// <summary>
/// Represents the interface for handling and enumerating registrars. For each registrar the list of encapsulated domains can be retrieved.
/// </summary>
public interface IRegistrarRepository : IRepository<Registrar, Guid>
{
    /// <summary>
    /// Asynchronously gets all registrars in the database and ensures that all domains of the registrars are loaded.
    /// </summary>
    /// <returns>The <see cref="Task"/> that asynchronously retrieves a list of all registrars with their domains.</returns>
    Task<List<Registrar>> GetAllWithDomainsAsync();

    /// <summary>
    /// Asynchronously ensures that the navigation property <see cref="Registrar.Domains"/> of <paramref name="registrar"/> had been loaded.
    /// </summary>
    /// <param name="registrar">The <see cref="Registrar"/> instance from which all domains should be loaded.</param>
    /// <returns>The <see cref="Task"/> that loads all domains for the given <paramref name="registrar"/>; or nothing if all domains are already loaded.</returns>
    Task EnsureDomainsAreLoadedAsync(Registrar registrar);
}

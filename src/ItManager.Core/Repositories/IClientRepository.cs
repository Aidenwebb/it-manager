using ItManager.Core.Models;

namespace ItManager.Core.Repositories;

public interface IClientRepository : IRepository<Client, Guid>
{
    /// <summary>
    /// Gets the institution with the given <paramref name="name"/> asynchronously.
    /// </summary>
    /// <param name="name">The name of the institution to find.</param>
    /// <returns>The <see cref="Client"/> with the given <paramref name="name"/> or <see langword="null"/> if no institution with the given <paramref name="name"/> exists.</returns>
    Task<Client?> GetInstitutionByNameAsync(string name);
}
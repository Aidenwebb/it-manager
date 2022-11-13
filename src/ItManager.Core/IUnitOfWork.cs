using ItManager.Core.Repositories;

namespace ItManager.Core;

public interface IUnitOfWork : IDisposable
{
    IClientRepository Institutions { get; }
    Task<int> CommitAsync();
}
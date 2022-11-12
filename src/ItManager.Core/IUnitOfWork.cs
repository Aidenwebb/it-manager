using ItManager.Core.Repositories;

namespace ItManager.Core;

public interface IUnitOfWork : IDisposable
{
    IInstitutionRepository Institutions { get; }
    Task<int> CommitAsync();
}
using JsgItManager.Core.Repositories;

namespace JsgItManager.Core;

public interface IUnitOfWork : IDisposable
{
    IInstitutionRepository Institutions { get; }
    Task<int> CommitAsync();
}
using ItManager.Core;
using ItManager.Core.Repositories;
using ItManager.Data.Repositories;

namespace ItManager.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly JsgItManagerDbContext _context;
    private ClientRepository? _institutionRepository;
    
    public UnitOfWork(JsgItManagerDbContext context)
    {
        _context = context;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }

    public IClientRepository Institutions => _institutionRepository ??= new ClientRepository(_context);
    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
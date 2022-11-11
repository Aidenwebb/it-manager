using JsgItManager.Core;
using JsgItManager.Core.Repositories;
using JsgItManager.Data.Repositories;

namespace JsgItManager.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly JsgItManagerDbContext _context;
    private InstitutionRepository _institutionRepository;
    
    public UnitOfWork(JsgItManagerDbContext context)
    {
        _context = context;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }

    public IInstitutionRepository Institutions => _institutionRepository ??= new InstitutionRepository(_context);
    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
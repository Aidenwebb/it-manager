using ItManager.Core.Models;
using ItManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ItManager.Data.Repositories;

public class InstitutionRepository: Repository<Institution, Guid>, IInstitutionRepository
{
    public InstitutionRepository(DbContext context) : base(context)
    {
    }
    
    public JsgItManagerDbContext? JsgItManagerDbContext => Context as JsgItManagerDbContext;
    
    /// <inheritdoc/>
    public Task<Institution?> GetInstitutionByNameAsync(string name)
    {
        return Find(i => i.Name == name).FirstOrDefaultAsync();
    }
}
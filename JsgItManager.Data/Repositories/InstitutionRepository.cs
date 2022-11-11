using JsgItManager.Core.Models;
using JsgItManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JsgItManager.Data.Repositories;

public class InstitutionRepository: Repository<Institution, Guid>, IInstitutionRepository
{
    public InstitutionRepository(DbContext context) : base(context)
    {
    }
    
    public JsgItManagerDbContext JsgItManagerDbContext => Context as JsgItManagerDbContext;
    public async Task<Institution> GetInstitutionByNameAsync(string name)
    {
        return base.Find(i => i.Name == name).FirstOrDefault();
    }
}
using ItManager.Core.Models;
using ItManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ItManager.Data.Repositories;

public class ClientRepository : Repository<Client, Guid>, IClientRepository
{
    public ClientRepository(JsgItManagerDbContext context) : base(context)
    {
    }
    
    /// <inheritdoc/>
    public Task<Client?> GetInstitutionByNameAsync(string name)
    {
        return Find(i => i.Name == name).FirstOrDefaultAsync();
    }
}
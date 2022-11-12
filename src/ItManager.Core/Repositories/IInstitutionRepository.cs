using ItManager.Core.Models;

namespace ItManager.Core.Repositories;

public interface IInstitutionRepository : IRepository<Institution, Guid>
{
    Task<Institution> GetInstitutionByNameAsync(string name);
    
}
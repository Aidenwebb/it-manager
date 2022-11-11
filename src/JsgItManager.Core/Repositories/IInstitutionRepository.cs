using JsgItManager.Core.Models;

namespace JsgItManager.Core.Repositories;

public interface IInstitutionRepository : IRepository<Institution, Guid>
{
    Task<Institution> GetInstitutionByNameAsync(string name);
    
}
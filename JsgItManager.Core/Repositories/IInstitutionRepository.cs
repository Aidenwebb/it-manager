using JsgItManager.Core.Models;

namespace JsgItManager.Core.Repositories;

public interface IInstitutionRepository : IRepository<Institution>
{
    Task<Institution> GetInstitutionByNameAsync(string name);
    
}
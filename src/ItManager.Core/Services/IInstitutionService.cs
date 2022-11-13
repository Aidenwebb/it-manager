using ItManager.Core.Models;

namespace ItManager.Core.Services;

public interface IInstitutionService
{
    Task<List<Institution>> GetAllInstitutions();
    Task<Institution?> GetInstitutionByIdAsync(Guid id);
    Task<Institution?> GetInstitutionByNameAsync(string name);
    Task<Institution> CreateInstitutionAsync(Institution institution);
    Task<Institution> UpdateInstitutionAsync(Institution institutionToBeUpdated, Institution institution);
    Task DeleteInstitutionAsync(Institution institution);
}
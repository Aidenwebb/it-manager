using JsgItManager.Core.Models;

namespace JsgItManager.Core.Services;

public interface IInstitutionService
{
    Task<IEnumerable<Institution>> GetAllInstitutions();
    Task<Institution> GetInstitutionByIdAsync(int id);
    Task<Institution> GetInstitutionByNameAsync(string name);
    Task<Institution> CreateInstitutionAsync(Institution institution);
    Task<Institution> UpdateInstitutionAsync(Institution institutionToBeUpdated, Institution institution);
    Task DeleteInstitutionAsync(Institution institution);
}
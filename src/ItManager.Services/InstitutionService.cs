using ItManager.Core;
using ItManager.Core.Models;
using ItManager.Core.Services;

namespace ItManager.Services;

public class InstitutionService : IInstitutionService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public InstitutionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public Task<List<Institution>> GetAllInstitutions()
    {
        return _unitOfWork.Institutions.GetAllAsync();
    }

    public async Task<Institution?> GetInstitutionByIdAsync(Guid id)
    {
        return await _unitOfWork.Institutions.GetByIdAsync(id);
    }

    public async Task<Institution?> GetInstitutionByNameAsync(string name)
    {
        return await  _unitOfWork.Institutions.GetInstitutionByNameAsync(name);
    }

    public async Task<Institution> CreateInstitutionAsync(Institution institution)
    {
        await _unitOfWork.Institutions.AddAsync(institution);
        await _unitOfWork.CommitAsync();
        return institution;
    }

    public async Task<Institution> UpdateInstitutionAsync(Institution institutionToBeUpdated, Institution institution)
    {
        institutionToBeUpdated.Name = institution.Name;

        await _unitOfWork.CommitAsync();

        return institutionToBeUpdated;
    }

    public async Task DeleteInstitutionAsync(Institution institution)
    {
        _unitOfWork.Institutions.Remove(institution);
        await _unitOfWork.CommitAsync();
    }
}
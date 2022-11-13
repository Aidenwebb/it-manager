using ItManager.Core;
using ItManager.Core.Models;
using ItManager.Core.Services;

namespace ItManager.Services;

public class ClientService : IClientService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public ClientService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public Task<List<Client>> GetAllClients()
    {
        return _unitOfWork.Institutions.GetAllAsync();
    }

    public async Task<Client?> GetClientByIdAsync(Guid id)
    {
        return await _unitOfWork.Institutions.GetByIdAsync(id);
    }

    public async Task<Client?> GetClientByNameAsync(string name)
    {
        return await  _unitOfWork.Institutions.GetInstitutionByNameAsync(name);
    }

    public async Task<Client> CreateClientAsync(Client institution)
    {
        await _unitOfWork.Institutions.AddAsync(institution);
        await _unitOfWork.CommitAsync();
        return institution;
    }

    public async Task<Client> UpdateClientAsync(Client institutionToBeUpdated, Client institution)
    {
        institutionToBeUpdated.Name = institution.Name;

        await _unitOfWork.CommitAsync();

        return institutionToBeUpdated;
    }

    public async Task DeleteClientAsync(Client institution)
    {
        _unitOfWork.Institutions.Remove(institution);
        await _unitOfWork.CommitAsync();
    }
}
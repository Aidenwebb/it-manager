using ItManager.Core.Models;

namespace ItManager.Core.Services;

public interface IClientService
{
    Task<List<Client>> GetAllClients();
    Task<Client?> GetClientByIdAsync(Guid id);
    Task<Client?> GetClientByNameAsync(string name);
    Task<Client> CreateClientAsync(Client institution);
    Task<Client> UpdateClientAsync(Client institutionToBeUpdated, Client institution);
    Task DeleteClientAsync(Client institution);
}
using ProjetoFinal_API.Models;
using ProjetoFinal_API.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal_API.Services.Interfaces
{
    public interface IClientService
    {
        Task<List<Client>> GetAllAsync();

        Task<Client> GetByIdAsync(int id);

        Task CreateAsync(Client client);

        Task UpdateAsync(Client client);

        Task DeleteAsync(int id);

        List<ClientDto> ConvertToListDto(List<Client> clients);
        ClientDto ConvertToDto(Client client);
    }
}

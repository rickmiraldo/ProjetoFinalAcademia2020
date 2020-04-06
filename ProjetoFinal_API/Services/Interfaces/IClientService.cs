using ProjetoFinal_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal_API.Services.Interfaces
{
    public interface IClientService
    {
        Task<List<Client>> GetAllAsync();

        Task<Client> GetByIdAsync();

        Task CreateAsync();

        Task UpdateAsync();

        Task DeleteAsync();
    }
}

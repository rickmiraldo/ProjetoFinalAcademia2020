﻿using ProjetoFinal_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal_Web.Services.Interfaces
{
    public interface IClientService
    {
        Task<List<Client>> GetAllAsync();

        Task<Client> GetByIdAsync(int id);

        Task CreateAsync(Client client);

        Task UpdateAsync(Client client);

        Task DeleteAsync(int id);

    }
}

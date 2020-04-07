using ProjetoFinal_Web.Models;
using ProjetoFinal_Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal_Web.Services
{
    public class SaleService : ISaleService
    {
        public Task CreateAsync(Sale sale)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sale>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Sale> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

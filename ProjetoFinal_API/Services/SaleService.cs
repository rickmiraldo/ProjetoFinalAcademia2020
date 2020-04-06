using Microsoft.EntityFrameworkCore;
using ProjetoFinal_API.Models;
using ProjetoFinal_API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal_API.Services
{
    public class SaleService : ISaleService
    {
        private readonly academiaContext context;

        public SaleService(academiaContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Sale>> GetAllAsync()
        {
            return await context.Sale.Include(x => x.SaleProduct).ToListAsync();
        }

        public async Task<Sale> GetByIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}

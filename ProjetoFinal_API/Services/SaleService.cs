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

        public async Task CreateAsync(Sale sale)
        {
            context.Add(sale);
            await context.SaveChangesAsync();
        }

        public async Task<List<Sale>> GetAllAsync()
        {
            return await context.Sale.Include(x => x.SaleProduct).ToListAsync();
        }

        public async Task<Sale> GetByIdAsync(int id)
        {
            return await context.Sale.FirstOrDefaultAsync(x => x.SaleId == id);
        }
    }
}

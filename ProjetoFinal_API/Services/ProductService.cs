using Microsoft.EntityFrameworkCore;
using ProjetoFinal_API.Models;
using ProjetoFinal_API.Services.Exceptions;
using ProjetoFinal_API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal_API.Services
{
    public class ProductService : IProductService
    {
        private readonly academiaContext context;

        public ProductService(academiaContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync(Product product)
        {
            context.Add(product);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var product = await context.Product.FindAsync(id);
                context.Remove(product);
                await context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                throw new IntegrityException("Can't delete product because it has sales associated.");
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await context.Product.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await context.Product.FirstOrDefaultAsync(x => x.ProductId == id);
        }

        public async Task UpdateAsync(Product product)
        {
            context.Update(product);
            await context.SaveChangesAsync();
        }
    }
}

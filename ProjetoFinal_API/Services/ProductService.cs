using Microsoft.EntityFrameworkCore;
using ProjetoFinal_API.Models;
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
        public async Task CreateAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await context.Product.ToListAsync();
        }

        public async Task<Product> GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}

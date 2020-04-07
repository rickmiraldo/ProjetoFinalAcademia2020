using ProjetoFinal_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal_Web.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int id);

        Task<Product> CreateAsync(Product product);

        Task UpdateAsync(Product product);

        Task DeleteAsync(int id);
    }
}

using ProjetoFinal_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal_API.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();

        Task<Product>GetByIdAsync(int id);

        Task CreateAsync(Product product);

        Task UpdateAsync(Product product);

        Task DeleteAsync();
    }
}

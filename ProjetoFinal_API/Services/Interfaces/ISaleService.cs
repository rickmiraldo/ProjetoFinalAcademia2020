using ProjetoFinal_API.Models;
using ProjetoFinal_API.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal_API.Services.Interfaces
{
    public interface ISaleService
    {
        Task<List<Sale>> GetAllAsync();

        Task<Sale> GetByIdAsync(int id);

        Task CreateAsync(Sale sale);

        List<SaleDto> ConvertToListDto(List<Sale> sales);

        SaleDto ConvertToDto(Sale sale);
    }
}

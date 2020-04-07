using Microsoft.EntityFrameworkCore;
using ProjetoFinal_API.Models;
using ProjetoFinal_API.Models.DTOs;
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
            return await context.Sale.Include(x => x.Client).Include(x => x.SaleProduct).ToListAsync();
        }

        public async Task<Sale> GetByIdAsync(int id)
        {
            return await context.Sale.Include(x => x.Client).Include(x => x.SaleProduct).FirstOrDefaultAsync(x => x.SaleId == id);
        }

        public List<SaleDto> ConvertToListDto(List<Sale> sales)
        {
            List<SaleDto> listDto = new List<SaleDto>();
            foreach (var sale in sales)
            {
                listDto.Add(ConvertToDto(sale));
            }
            return listDto;
        }

        public SaleDto ConvertToDto(Sale sale)
        {
            return new SaleDto
            {
                ClientName = sale.Client.NameClient,
                SaleDate = sale.SaleDate,
                SaleId = sale.SaleId,
                TotalValue = sale.TotalValue,
                SaleProduct = sale.SaleProduct
            };
        }
    }
}

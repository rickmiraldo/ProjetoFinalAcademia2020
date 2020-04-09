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

        public async Task<Sale> CreateAsync(Sale sale)
        {
            int stock = 0;
            foreach (var saleProduct in sale.SaleProduct)
            {
               stock = context.Product.Where(p => p.ProductId == saleProduct.ProductId).Select(p => p.Stock).First();
                if (stock == 0 || saleProduct.Quantity > stock)
                {
                    throw new Exception("There is no stock for this product.");
                }
            }
            

            context.Add(sale);
            await context.SaveChangesAsync();

            return sale;
        }

        public async Task<Sale> ConvertFromDtoAsync (SaleDto saleDto)
        {
            var client = await context.Client.Where(x => x.NameClient== saleDto.ClientName).FirstOrDefaultAsync();
            return new Sale{ SaleDate= saleDto.SaleDate, SaleProduct= saleDto.SaleProduct, Client= client, ClientId= client.ClientId, TotalValue= saleDto.TotalValue};
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
            string nameClient = "";
            if (sale.Client == null)
            {
                nameClient = "Unknown";
            }
            else
            {
                nameClient = sale.Client.NameClient;
            }

            return new SaleDto
            {
                ClientName = nameClient,
                SaleDate = sale.SaleDate,
                SaleId = sale.SaleId,
                TotalValue = sale.TotalValue,
                SaleProduct = sale.SaleProduct
            };
        }
    }
}

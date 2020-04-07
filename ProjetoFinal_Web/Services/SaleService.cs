using Newtonsoft.Json;
using ProjetoFinal_Web.Models;
using ProjetoFinal_Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjetoFinal_Web.Services
{
    public class SaleService : ISaleService
    {
        public Task CreateAsync(Sale sale)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Sale>> GetAllAsync()
        {
            List<Sale> sales = new List<Sale>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44343/api/sales/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    sales = JsonConvert.DeserializeObject<List<Sale>>(apiResponse);
                }
                return sales;
            }
        }

        public Task<Sale> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

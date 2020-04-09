using Newtonsoft.Json;
using ProjetoFinal_Web.Models;
using ProjetoFinal_Web.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjetoFinal_Web.Services
{
    public class SaleService : ISaleService
    {
        public async Task<Sale> CreateAsync(Sale sale)
        {
            Sale createdSale = new Sale();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(sale), System.Text.Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44343/api/sales/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    createdSale = JsonConvert.DeserializeObject<Sale>(apiResponse);
                }
            }
            return createdSale;
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

        public async Task<Sale> GetByIdAsync(int id)
        {
            Sale sale = new Sale();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44343/api/sales/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    sale = JsonConvert.DeserializeObject<Sale>(apiResponse);
                }
            }
            return sale;
        }

        public List<Product> GetProductsForSale(Sale sale, List<Product> allProducts)
        {
            var productsList = new List<Product>();
            for (int i = 0; i < allProducts.Count; i++)
            {
                for (int j = 0; j < sale.SaleProduct.Count; j++)
                {
                    if (allProducts.ElementAt(i).ProductId == sale.SaleProduct.ElementAt(j).ProductId)
                    {
                        productsList.Add(allProducts.ElementAt(i));
                    }
                }
            }
            return productsList;
        }
    }
}

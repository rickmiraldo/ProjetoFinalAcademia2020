﻿using Newtonsoft.Json;
using ProjetoFinal_Web.Models;
using ProjetoFinal_Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjetoFinal_Web.Services
{
    public class ProductService : IProductService
    {
        public async Task<Product> CreateAsync(Product product)
        {
            Product createdProduct = new Product();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(product), System.Text.Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44343/api/products/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    createdProduct = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return createdProduct;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            List<Product> products = new List<Product>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44343/api/products/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                }
            }
            return products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            Product product = new Product();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44343/api/products/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    product = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return product;
        }

        public Task UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}

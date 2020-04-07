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
    public class ClientService : IClientService
    {
        public async Task<Client> CreateAsync(Client client)
        {
            Client createdClient = new Client();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(client), System.Text.Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44343/api/clients/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    createdClient = JsonConvert.DeserializeObject<Client>(apiResponse);
                }
            }
            return createdClient;
        }

        public async Task DeleteAsync(int id)
        {  
            using (var httpClient = new HttpClient())
            {
               
                using (var response = await httpClient.DeleteAsync("https://localhost:44343/api/clients/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task<List<Client>> GetAllAsync()
        {
            List<Client> clients = new List<Client>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44343/api/clients/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    clients = JsonConvert.DeserializeObject<List<Client>>(apiResponse);
                }
            }
            return clients;
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            Client client = new Client();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44343/api/clients/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    client = JsonConvert.DeserializeObject<Client>(apiResponse);
                }
            }
            return client;
        }

        public Task UpdateAsync(Client client)
        {
            throw new NotImplementedException();
        }
    }
}

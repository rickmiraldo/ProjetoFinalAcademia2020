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
    public class ClientService : IClientService
    {
        private readonly academiaContext context;

        public ClientService(academiaContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Client client)
        {
            context.Add(client);
            await context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var client = await context.Client.FindAsync(id);
            context.Remove(client);
            await context.SaveChangesAsync();
        }

        public async Task<List<Client>> GetAllAsync()
        {
            // Pode ser necessário remover os includes caso se queira apenas as informações do cliente 
            return await context.Client.ToListAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await context.Client.Include(x => x.Sale).FirstOrDefaultAsync(x=> x.ClientId == id);
        }

        public async Task UpdateAsync(Client client)
        {
            context.Update(client);
            await context.SaveChangesAsync();
        }

        public List<ClientDto> ConvertToListDto (List<Client> clients)
        {
            List<ClientDto> listDto = new List<ClientDto>();
            foreach (var client in clients)
            {
                listDto.Add(ConvertToDto(client));
            }
            return listDto;
        }

        public ClientDto ConvertToDto(Client client)
        {
            return new ClientDto
            {
                Id = client.ClientId,
                NameClient = client.NameClient,
                BirthDate = client.BirthDate,
                RegistDate = client.RegistDate,
                Gender = client.Gender,
                Mobile = client.Mobile
            };
        }
    }
}

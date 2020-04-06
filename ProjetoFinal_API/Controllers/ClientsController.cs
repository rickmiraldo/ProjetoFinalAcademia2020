using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal_API.Models;
using ProjetoFinal_API.Services.Interfaces;

namespace ProjetoFinal_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {

        private readonly IClientService clientService;

        public ClientsController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        
        // GET: api/Clients
        [HttpGet]
        public async Task<IEnumerable<Client>> Get()
        {
            var clients = await clientService.GetAllAsync();
            return clients;
        }

        // GET: api/Clients/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Client> Get(int id)
        {
            var client = await clientService.GetByIdAsync(id);
            return client;
        }

        // POST: api/Clients
        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            if (ModelState.IsValid)
            {
                await clientService.CreateAsync(client);
                return CreatedAtAction(nameof(Get), new { id = client.ClientId }, client);
            }
            return BadRequest();
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

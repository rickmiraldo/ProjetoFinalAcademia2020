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
    public class SalesController : ControllerBase
    {
        private readonly ISaleService saleService;

        public SalesController(ISaleService saleService)
        {
            this.saleService = saleService;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<IEnumerable<Sale>> GetSale()
        {
            return await saleService.GetAllAsync();
        }

        // GET: api/Sales
        [HttpGet("{id}")]
        public async Task<Sale> GetSale([FromRoute] int id)
        {
            return await saleService.GetByIdAsync(id);
        }

        // POST: api/Sales
        [HttpPost]
        public async Task<IActionResult> Create(Sale sale)
        {
            if (ModelState.IsValid)
            {
                await saleService.CreateAsync(sale);
                return CreatedAtAction(nameof(GetSale), new { id = sale.SaleId }, sale);
            }
            return BadRequest();
        }
    }
}
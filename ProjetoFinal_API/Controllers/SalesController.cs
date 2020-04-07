using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal_API.Models;
using ProjetoFinal_API.Models.DTOs;
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
        public async Task<IEnumerable<SaleDto>> GetSale()
        {
            var sales = await saleService.GetAllAsync();

            return saleService.ConvertToListDto(sales);

        }

        // GET: api/Sales
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSale([FromRoute] int id)
        { 

            var result = await saleService.GetByIdAsync(id);
            if (result == null)
            {
                return BadRequest(new { Message = "The requested sale does not exist." });
            }
            return Ok(result);
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
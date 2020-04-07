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
        public async Task<IActionResult> GetSaleById([FromRoute] int id)
        { 

            var result = await saleService.GetByIdAsync(id);
            if (result == null)
            {
                return BadRequest(new { Message = "The requested sale does not exist." });
            }
            return Ok(saleService.ConvertToDto(result));
        }

        // POST: api/Sales
        [HttpPost]
        public async Task<IActionResult> Create(SaleDto saleDto)
        {
            if (ModelState.IsValid)
            {
                var sale = await saleService.ConvertFromDtoAsync(saleDto);
                var created = await saleService.CreateAsync(sale);

                var Dto = saleService.ConvertToDto(created);
                return CreatedAtAction(nameof(GetSaleById), new { id = Dto.SaleId }, Dto);
            }
            return BadRequest();
        }
    }
}
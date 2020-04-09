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
        private readonly IProductService productService;

        public SalesController(ISaleService saleService, IProductService productService)
        {
            this.saleService = saleService;
            this.productService = productService;
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
                try
                {
                    var sale = await saleService.ConvertFromDtoAsync(saleDto);

                    var created = await saleService.CreateAsync(sale);
                    foreach (var saleProduct in sale.SaleProduct)
                    {
                        await productService.DecreaseStock(saleProduct.ProductId, saleProduct.Quantity);
                    }

                    var Dto = saleService.ConvertToDto(created);
                    return CreatedAtAction(nameof(GetSaleById), new { id = Dto.SaleId }, Dto);
                }
                catch (Exception)
                {

                    return BadRequest();
                }
              
            }
            return BadRequest();
        }
    }
}
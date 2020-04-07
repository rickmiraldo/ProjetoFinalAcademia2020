using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal_API.Models;
using ProjetoFinal_API.Services.Interfaces;

namespace ProjetoFinal_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProduct()
        {
            return await productService.GetAllAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var result = await productService.GetByIdAsync(id);
            if (result == null)
            {
                return BadRequest(new { Message = "The requested product does not exist." });
            }
            return Ok(result);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest(new { Message = "Ids don't match." });
            }
            try
            {
                await productService.UpdateAsync(product);
                return NoContent();
            }
            catch(ApplicationException e)
            {
                return BadRequest(new { e.Message });
            }
            
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await productService.CreateAsync(product);
                return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
            }
            return BadRequest();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var p = await productService.GetByIdAsync(id);
            if (p == null)
            {
                return BadRequest(new { Message = "Product does not exist." });
            }
            await productService.DeleteAsync(id);
            return Ok(p);
        }
    }
}
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
        public async Task<Product> GetProduct([FromRoute] int id)
        {
            return await productService.GetByIdAsync(id);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            await productService.UpdateAsync(product);
            return NoContent();
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
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var product = await _context.Product.FindAsync(id);
            //if (product == null)
            //{
            //    return NotFound();
            //}

            //_context.Product.Remove(product);
            //await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ProductExists(int id)
        {
            //return _context.Product.Any(e => e.ProductId == id);
            return true;
        }
    }
}
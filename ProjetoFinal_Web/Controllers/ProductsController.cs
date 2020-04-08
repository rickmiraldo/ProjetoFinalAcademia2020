using Microsoft.AspNetCore.Mvc;
using ProjetoFinal_Web.Models;
using ProjetoFinal_Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal_Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await productService.GetAllAsync();
            return View(result);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var result = await productService.GetByIdAsync(id.Value);
            if (result == null)
            {
                return View();
            }
            return View(result);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var response = await productService.CreateAsync(product);
                if (response == null)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteAction(int id)
        {
            await productService.DeleteAsync(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await productService.GetByIdAsync((int)id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        
        // RETURNS DELETE PAGE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await productService.GetByIdAsync(id.Value);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Update")]
        public async Task<IActionResult> Update(int id, Product product)      
        {
            if (product.ProductId != id)
            {
                return BadRequest();
            }

            await productService.UpdateAsync(product);

            return RedirectToAction("Index");
        }
    }
}

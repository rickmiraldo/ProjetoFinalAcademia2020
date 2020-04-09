using Microsoft.AspNetCore.Mvc;
using ProjetoFinal_Web.Models;
using ProjetoFinal_Web.Models.ViewModels;
using ProjetoFinal_Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal_Web.Controllers
{
    public class SalesController : Controller
    {
        private readonly ISaleService saleService;
        private readonly IProductService productService;

        public SalesController(ISaleService saleService, IProductService productService)
        {
            this.saleService = saleService;
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await saleService.GetAllAsync();
            return View(result);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var sale = await saleService.GetByIdAsync(id.Value);
            if (sale == null)
            {
                return View();
            }
            var products = await productService.GetAllAsync();
            var saleProducts = saleService.GetProductsForSale(sale, products);

            var salesWithProductsViewModel = new SalesWithProductsViewModel { 
                Sale = sale,
                Products = saleProducts
            };
            return View(salesWithProductsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Sale sale)
        {
            if (ModelState.IsValid)
            {
                var response = await saleService.CreateAsync(sale);
                if (response == null)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ProjetoFinal_Web.Models;
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

        public SalesController(ISaleService saleService)
        {
            this.saleService = saleService;
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
            var result = await saleService.GetByIdAsync(id.Value);
            if (result == null)
            {
                return View();
            }
            return View(result);
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

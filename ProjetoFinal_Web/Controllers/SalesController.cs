using Microsoft.AspNetCore.Mvc;
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
    }
}

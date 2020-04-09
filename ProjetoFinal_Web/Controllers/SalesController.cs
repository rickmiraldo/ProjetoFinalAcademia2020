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
        private readonly IClientService clientService;
        private readonly IProductService productService;

        public SalesController(ISaleService saleService, IClientService clientService, IProductService productService)
        {
            this.saleService = saleService;
            this.clientService = clientService;
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
            var result = await saleService.GetByIdAsync(id.Value);
            if (result == null)
            {
                return View();
            }
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            SaleFormViewModel saleFormViewModel = new SaleFormViewModel();
            saleFormViewModel.Clients = await clientService.GetAllAsync();
            saleFormViewModel.Products = await productService.GetAllAsync();

            return View(saleFormViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaleFormViewModel saleFormViewModel)
        {
            if (ModelState.IsValid)
            {
                List<SaleProduct> saleProductList = new List<SaleProduct>();
                double totalValue = 0;

                foreach (var saleProduct in saleFormViewModel.SaleProducts)
                {
                    saleProductList.Add(saleProduct);
                    totalValue += saleProduct.Quantity * saleProduct.UnitPrice;
                }

                Sale sale = new Sale()
                {
                    SaleProduct = saleProductList,
                    ClientName = saleFormViewModel.Sale.ClientName,
                    SaleDate = saleFormViewModel.Sale.SaleDate,
                    TotalValue = totalValue
                };

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

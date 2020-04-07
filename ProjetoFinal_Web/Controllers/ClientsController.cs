using Microsoft.AspNetCore.Mvc;
using ProjetoFinal_Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal_Web.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService clientService;

        public ClientsController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await clientService.GetAllAsync();
            return View(result);
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var result = await clientService.GetByIdAsync(id.Value);
            if (result == null)
            {
                return View();
            }
            return View(result);
        }
    }
}

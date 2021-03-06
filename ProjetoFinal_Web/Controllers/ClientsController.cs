﻿using Microsoft.AspNetCore.Mvc;
using ProjetoFinal_Web.Models;
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

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            if (ModelState.IsValid)
            {
                var response= await clientService.CreateAsync(client);
                if(response == null)
                {
                  return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await clientService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await clientService.GetByIdAsync((int)id);

            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        
        // RETURNS DELETE PAGE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await clientService.GetByIdAsync(id.Value);

            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        [HttpPost, ActionName("Update")]
        public async Task<IActionResult> Update(int id, Client client)
        {
            if (client.ClientId != id)
            {
                return BadRequest();
            }

            await clientService.UpdateAsync(client);

            return RedirectToAction("Index");
        }

    }
}

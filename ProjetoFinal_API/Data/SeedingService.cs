//using ProjetoFinal_API.Models;
using ProjetoFinal_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal_API.Data
{
    public class SeedingService
    {
        private academiaContext context;

        public SeedingService(academiaContext context)
        {
            this.context = context;
        }

        public void Seed()
        {
            if (context.Product.Any() || context.Client.Any())
           {
               return;
           }


           
        }
    }
}

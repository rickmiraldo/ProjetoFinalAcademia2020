using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal_Web.Models.ViewModels
{
    public class SaleFormViewModel
    {
        public Sale Sale { get; set; }

        public ICollection<Client> Clients { get; set; }

        public List<SaleProduct> SaleProducts { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}

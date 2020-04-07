using ProjetoFinal_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal_Web.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int Stock { get; set; }

        public ICollection<SaleProduct> SaleProduct { get; set; } = new List<SaleProduct>();

        public Product()
        {
        }
    }
}

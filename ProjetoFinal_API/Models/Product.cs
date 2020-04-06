using System;
using System.Collections.Generic;

namespace ProjetoFinal_API.Models
{
    public partial class Product
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

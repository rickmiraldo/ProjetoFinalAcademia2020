using System;
using System.Collections.Generic;

namespace ProjetoFinal_API.Models
{
    public partial class SaleProduct
    {
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
        public Sale Sale { get; set; }
    }
}

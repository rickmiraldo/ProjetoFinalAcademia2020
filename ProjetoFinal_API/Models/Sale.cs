using System;
using System.Collections.Generic;

namespace ProjetoFinal_API.Models
{
    public partial class Sale
    {
        public Sale()
        {
            SaleProduct = new HashSet<SaleProduct>();
        }

        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public double TotalValue { get; set; }
        public int? ClientId { get; set; }

        public Client Client { get; set; }
        public ICollection<SaleProduct> SaleProduct { get; set; }
    }
}

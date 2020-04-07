using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal_Web.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public double TotalValue { get; set; }
        public string ClientName { get; set; }
        public ICollection<SaleProduct> SaleProduct { get; set; }
    }
}

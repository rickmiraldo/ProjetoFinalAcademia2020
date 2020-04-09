using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal_API.Models.DTOs
{
    public class SaleDto
    {
        public string ClientName { get; set; }
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public double TotalValue { get; set; }
        public ICollection<SaleProduct> SaleProduct { get; set; }
    }
}

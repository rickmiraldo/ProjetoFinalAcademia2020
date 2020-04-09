using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal_Web.Models
{
    public class Sale
    {
        public int SaleId { get; set; }

        [Display(Name = "Sale Date")]
        public DateTime SaleDate { get; set; } = DateTime.Now;

        [Display(Name = "Total Value" )]

        [Display(Name = "Total Value")]
        public double TotalValue { get; set; }

        [Display(Name = "Client Name")]
        public string ClientName { get; set; }

        public ICollection<SaleProduct> SaleProduct { get; set; }
    }
}

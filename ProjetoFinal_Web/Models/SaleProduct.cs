using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal_Web.Models
{
    public class SaleProduct
    {
        public int Quantity { get; set; }

        [Display(Name = "Unit Price")]
        public double UnitPrice { get; set; }

        [Display(Name = "Product Name")]
        public int ProductId { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ProjetoFinal_API.Models
{
    public partial class Sale
    {

        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public double TotalValue { get; set; }

        [JsonIgnore]
        public int? ClientId { get; set; }
        [JsonIgnore]
        public Client Client { get; set; }
        public ICollection<SaleProduct> SaleProduct { get; set; } = new List<SaleProduct>();
    }
}

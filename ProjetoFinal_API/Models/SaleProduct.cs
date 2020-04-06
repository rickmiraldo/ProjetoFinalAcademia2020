using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ProjetoFinal_API.Models
{
    public partial class SaleProduct
    {
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        [JsonIgnore]
        public int SaleId { get; set; }
        [JsonIgnore]
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        [JsonIgnore]
        public Sale Sale { get; set; }
    }
}

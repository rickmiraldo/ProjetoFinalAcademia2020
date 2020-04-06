using System;
using System.Collections.Generic;

namespace ProjetoFinal_API.Models
{
    public partial class Client
    {
        

        public int ClientId { get; set; }
        public string NameClient { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistDate { get; set; }
        public string Gender { get; set; }
        public int? Mobile { get; set; }

        public ICollection<Sale> Sale { get; set; } = new List<Sale>();

        public Client()
        {
        }


    }
}

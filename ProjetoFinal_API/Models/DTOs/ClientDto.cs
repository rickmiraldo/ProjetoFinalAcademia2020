using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal_API.Models.DTOs
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string NameClient { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistDate { get; set; }
        public string Gender { get; set; }
        public int? Mobile { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal_Web.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        [Display(Name = "Name")]
        public string NameClient { get; set; }

        [Required(ErrorMessage ="{0} required")]
        [Display(Name = "Birth Date" )]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Regist Date")]
        public DateTime RegistDate { get; set; } = DateTime.Now;

        public string Gender { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public int? Mobile { get; set; }

       
        public Client()
        {
        }

    }
}

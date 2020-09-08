using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk_SGVW.Models
{
    public class Opvolgers
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Voornaam")]
        [Required]
        public string Voornaam { get; set; }

        [Display(Name = "Familienaam")]
        [Required]
        public string Familienaam { get; set; }

        [Display(Name = "Displaynaam")]
        [Required]
        public string Displaynaam { get; set; }

        [Display(Name = "email")]
        [Required]
        public string Email { get; set; }
    }
}



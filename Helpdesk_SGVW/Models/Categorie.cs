using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk_SGVW.Models
{
    public class Categorie
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Categorie")]
        [Required]
        public string Naam { get; set; }

        [Display(Name = "Logo")]
        public string Logo { get; set; }

        [Display(Name = "Verantwoordelijke")]
        public string Verantwoordelijke { get; set; }

        [Display(Name = "Verantwoordelijke 2")]
        public string Verantwoordelijke2 { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk_SGVW.Models
{
    public class SubCategorie
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Subcategorie")]
        [Required]
        public string Subcategorie { get; set; }

        [Required]
        [Display(Name = "Categorie")]
        public int CategorieId { get; set; }

        [ForeignKey("CategorieId")]
        public virtual Categorie Categorie { get; set; }

        [Display(Name = "Verantwoordelijke")]
        public string Verantwoordelijke { get; set; }

        [Display(Name = "Verantwoordelijke 2")]
        public string Verantwoordelijke2 { get; set; }
    }
}

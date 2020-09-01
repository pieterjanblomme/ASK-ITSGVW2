using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk_SGVW.Models
{
    public class Infotheek
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Titel")]
        public string Titel { get; set; }

        [Display(Name = "Omschrijving")]
        public string Omschrijving { get; set; }

        [Display(Name = "Datum upload")]
        public DateTime Datum { get; set; } = DateTime.Now;

        [Display(Name = "Type")]
        public string Type { get; set; }
        public enum EType { Instructiefilmpje = 1, Webinar = 2, Handleiding = 3, Site = 4 }

        [Display(Name = "Categorie")]
        public int CategorieId { get; set; }

        [ForeignKey("CategorieId")]
        public virtual Categorie Categorie { get; set; }

        [Display(Name = "Subcategorie")]
        public int SubCategorieId { get; set; }

        [ForeignKey("SubCategorieId")]
        public virtual SubCategorie SubCategorie { get; set; }

        [Display(Name = "Tag1")]
        public string Tag1 { get; set; }

        [Display(Name = "Tag2")]
        public string Tag2 { get; set; }

        [Display(Name = "Tag3")]
        public string Tag3 { get; set; }

        [Display(Name = "Url")]
        public string Url { get; set; }

    }
}

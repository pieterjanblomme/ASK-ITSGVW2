using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;


namespace Helpdesk_SGVW.Models
{

    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Datum")]
        public DateTime Datum { get; set; } = DateTime.Now;

        [Display(Name = "Aanvrager")]
        public string Aanvrager { get; set; }

        [Display(Name = "EmailAanvrager")]
        public string EmailAanvrager { get; set; }

        [Display(Name = "Omschrijving")]
        public string Omschrijving { get; set; }

        [Display(Name = "Urgentie")]
        public string Urgentie { get; set; }
        public enum EUrgentie { Laag = 1, Hoog = 2, Prioritair = 3 }

        [Display(Name = "Screenshot")]
        public string Screenshot { get; set; }

        [Display(Name = "Categorie")]
        public int CategorieId { get; set; }

        [ForeignKey("CategorieId")]
        public virtual Categorie Categorie { get; set; }

        [Display(Name = "Subcategorie")]
        public int SubCategorieId { get; set; }

        [ForeignKey("SubCategorieId")]
        public virtual SubCategorie SubCategorie { get; set; }

        [Display(Name = "School")]
        public int SchoolId { get; set; }

        [ForeignKey("SchoolId")]
        public virtual School School { get; set; }

        [Display(Name = "Lokaal")]
        public string Lokaal { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; } 
        public enum EStatus { Open = 1, Opgevolgd = 2, Afgewerkt = 3 }

        [Display(Name = "Opvolger")]
        public string Opvolger { get; set; }
        public enum EOpvolger { Niemand, André, Frederick, Pieterjan, Sander, Patrick}

        [Display(Name = "Uitleg")]
        public string Uitleg { get; set; }

    }


}

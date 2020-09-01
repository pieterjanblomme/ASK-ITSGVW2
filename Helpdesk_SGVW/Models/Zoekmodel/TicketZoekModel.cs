using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Helpdesk_SGVW.Data;
using Helpdesk_SGVW.Models;
using Helpdesk_SGVW.Models.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpdesk_SGVW.Models.Zoekmodel
{
    public class TicketZoekModel
    {

        [Display(Name = "Datum")]
        public DateTime Datum { get; set; } = DateTime.Now;

        [Display(Name = "Aanvrager")]
        public string Aanvrager { get; set; }

        [Display(Name = "Omschrijving probleem")]
        public string Omschrijving { get; set; }

        [Display(Name = "Urgentie")]
        public string Urgentie { get; set; }
        public enum EUrgentie { Laag = 1, Hoog = 2, Prioritair = 3 }

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

        [Display(Name = "Status")]
        public string Status { get; set; }
        public enum EStatus { Open = 1, Opgevolgd = 2, Afgewerkt = 3 }

        [Display(Name = "Opvolging door")]
        public string Opvolger { get; set; }
        public enum EOpvolger { Niemand = 0, André = 1, Frederick = 2, Pieterjan = 3, Sander = 4 }

        [Display(Name = "Bijkomende uitleg")]
        public string Uitleg { get; set; }

        public List<Ticket>Tickets { get; set; }

    }

    //public class TicketZoekLogica
    //{
    //    private LearningContext db = new LearningContext();
    //}
}


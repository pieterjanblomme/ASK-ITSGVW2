using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk_SGVW.Models.ViewModel
{
    public class TicketViewModel
    {
        public Ticket Ticket { get; set; }
        public IEnumerable<Categorie> Categorie { get; set; }
        public IEnumerable<SubCategorie> SubCategorie { get; set; }
        public IEnumerable<School> School { get; set; }
        public int Aantal { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk_SGVW.Models.ViewModel
{
    public class OverzichtViewModel
    {
        public IEnumerable<Ticket> Ticket { get; set; }
        public IEnumerable<Categorie> Categorie { get; set; }
        public IEnumerable<School> School { get; set; }
        public IEnumerable<Ticket> Status { get; set; }
    }
}

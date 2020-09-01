using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk_SGVW.Models.ViewModel
{
    public class InfotheekViewModel
    {
        public Infotheek Infotheek { get; set; }
        public IEnumerable<Ticket> Ticket { get; set; }
        public IEnumerable<Categorie> Categorie { get; set; }
        public IEnumerable<SubCategorie> SubCategorie { get; set; }

    }
}

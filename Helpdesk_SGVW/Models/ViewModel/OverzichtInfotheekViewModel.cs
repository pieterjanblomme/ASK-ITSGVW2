using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk_SGVW.Models.ViewModel
{
    public class OverzichtInfotheekViewModel
    {
        public IEnumerable<Categorie> Categorie { get; set; }
        public IEnumerable<SubCategorie> SubCategorie { get; set; }
        public IEnumerable<Infotheek> Infotheek { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk_SGVW.Models.ViewModel
{
    public class SubCategorieEnCategorieViewModel
    {
        public IEnumerable<Categorie> CategorieLijst { get; set; }
        public SubCategorie SubCategorie { get; set; }
        public List<string> SubCategorieLijst { get; set; }
        public string StatusBericht { get; set; }
    }
}

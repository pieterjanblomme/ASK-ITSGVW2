using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk_SGVW.Models
{
    public class Personeel : IdentityUser
    {
        public string Naam { get; set; }
        public string Voornaam { get; set; }


    }
}

using Helpdesk_SGVW.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk_SGVW.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Categorie> Categorie { get; set; }
        public DbSet<SubCategorie> SubCategorie { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<Personeel> Personeel { get; set; }
        public DbSet<Infotheek> Infotheek { get; set; }

    }
}

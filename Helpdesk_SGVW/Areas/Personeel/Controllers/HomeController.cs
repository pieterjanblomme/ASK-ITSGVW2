using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Helpdesk_SGVW.Models;
using Helpdesk_SGVW.Data;
using Helpdesk_SGVW.Models.ViewModel;
using System.Net.Mail;
using System.Net;

namespace Helpdesk_SGVW.Controllers
{
    [Area("Personeel")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<IActionResult> Index()
        {
            IndexViewModel IndexVM = new IndexViewModel()
            {
                Ticket = await _db.Ticket.Include(m => m.Categorie).Include(m=>m.SubCategorie).ToListAsync(),
                Categorie = await _db.Categorie.ToListAsync(),
                //School = await _db.School.Where(c => c.IsActive == true).ToListAsync()

            };

            return View(IndexVM);
        }

        [Authorize(Roles = "Manager")]
        public IActionResult Privacy()
        { 
            return View();
        }

        
        public async Task<IActionResult> Overzicht()
        {
            OverzichtViewModel OverzichtVM = new OverzichtViewModel()
            {
                Ticket = await _db.Ticket.Include(m => m.Categorie).Include(m => m.SubCategorie).ToListAsync(),
                Categorie = await _db.Categorie.ToListAsync(),
                //School = await _db.School.Where(c => c.IsActive == true).ToListAsync()

            };

            return View(OverzichtVM);
        }


        public async Task<IActionResult> OverzichtInfotheek()
        {
            OverzichtInfotheekViewModel OverzichtInfotheekVM = new OverzichtInfotheekViewModel()
            {
                Infotheek = await _db.Infotheek.Include(m => m.Categorie).Include(m => m.SubCategorie).ToListAsync(),
                Categorie = await _db.Categorie.ToListAsync(),
                //School = await _db.School.Where(c => c.IsActive == true).ToListAsync()

            };

            return View(OverzichtInfotheekVM);
        }



        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}

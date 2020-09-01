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
using Helpdesk_SGVW.Models.Zoekmodel;
using Helpdesk_SGVW.Services;
using MimeKit;
using MailKit.Net.Smtp;

namespace Helpdesk_SGVW.Areas.Personeel.Controllers
{
    [Area("Personeel")]
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        [BindProperty]
        public TicketViewModel TicketVM { get; set; }



        public TicketController(ApplicationDbContext db, IWebHostEnvironment hostingEnvironment)
        {
            _context = db;
            _hostingEnvironment = hostingEnvironment;
            TicketVM = new TicketViewModel()
            {
                Categorie = _context.Categorie,
                School = _context.School,

                Ticket = new Ticket(),
            };

        }

        // GET: Personeel/Ticket
        public async Task<IActionResult> Index(string sortOrder, int zoektermId, string zoektermOmschrijving, string zoektermAanvrager, string zoektermCategorie, string zoektermSchool, string zoektermOpvolger, string zoektermStatus)
        {

            var applicationDbContext = _context.Ticket.Include(m => m.Categorie).Include(m => m.SubCategorie).Include(m => m.School);

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "aanvrager_desc" : "";
            ViewBag.SchoolSortParm = String.IsNullOrEmpty(sortOrder) ? "school_desc" : "";
            ViewBag.UrgentieSortParm = String.IsNullOrEmpty(sortOrder) ? "urgentie_desc" : "";
            ViewBag.CategorieSortParm = String.IsNullOrEmpty(sortOrder) ? "categorie_desc" : "";
            ViewBag.SubCategorieSortParm = String.IsNullOrEmpty(sortOrder) ? "subcategorie_desc" : "";
            ViewBag.StatusSortParm = String.IsNullOrEmpty(sortOrder) ? "status_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var tickets = from s in _context.Ticket
                          select s;



            //if (zoektermId == 0) { zoektermId = ""; };
            if (string.IsNullOrEmpty(zoektermOmschrijving)) { zoektermOmschrijving = ""; };
            if (string.IsNullOrEmpty(zoektermAanvrager)) { zoektermAanvrager = ""; };
            if (string.IsNullOrEmpty(zoektermCategorie)) { zoektermCategorie = ""; };
            if (string.IsNullOrEmpty(zoektermSchool)) { zoektermSchool = ""; };
            //if (string.IsNullOrEmpty(zoektermStatus)) { zoektermStatus = ""; };

            switch (zoektermOpvolger)
            {
                case "Niemand":
                    zoektermOpvolger = "0";
                    break;
                case "André":
                    zoektermOpvolger = "1";
                    break;
                case "Frederick":
                    zoektermOpvolger = "2";
                    break;
                case "Pieterjan":
                    zoektermOpvolger = "3";
                    break;
                case "Sander":
                    zoektermOpvolger = "4";
                    break;
                case null:
                    zoektermOpvolger = "";
                    break;
            };

            switch (zoektermStatus)
            {
                case "Open":
                    zoektermStatus = "1";
                    break;
                case "Opgevolgd":
                    zoektermStatus = "2";
                    break;
                case "Afgewerkt":
                    zoektermStatus = "3";
                    break;
                case null:
                    zoektermStatus = "";
                    break;
            }

            if (!string.IsNullOrEmpty(zoektermAanvrager) || !string.IsNullOrEmpty(zoektermOmschrijving) || !string.IsNullOrEmpty(zoektermCategorie) || !string.IsNullOrEmpty(zoektermSchool) || !string.IsNullOrEmpty(zoektermOpvolger) || !string.IsNullOrEmpty(zoektermSchool) || !string.IsNullOrEmpty(zoektermStatus))
            {
                tickets =

                    applicationDbContext
                    //.Where(s => s.Id.Equals(zoektermId))
                    .Where(s => s.Aanvrager.Contains(zoektermAanvrager))
                    .Where(s => s.Omschrijving.Contains(zoektermOmschrijving))
                    .Where(s => s.Categorie.Naam.Contains(zoektermCategorie))
                    .Where(s => s.School.Naam.Contains(zoektermSchool))
                    .Where(s => s.Opvolger.Contains(zoektermOpvolger))
                    .Where(s => s.Status.Contains(zoektermStatus));
            }
            else if (zoektermId != 0)
            {
                tickets =

                    applicationDbContext
                    .Where(s => s.Id.Equals(zoektermId));
            }
            else
            {
                tickets = applicationDbContext;
            }



            switch (sortOrder)
            {
                case "aanvrager_desc":
                    tickets = tickets.OrderByDescending(s => s.Aanvrager);
                    break;

                case "school_desc":
                    tickets = tickets.OrderByDescending(s => s.School);
                    break;

                case "urgentie_desc":
                    tickets = tickets.OrderByDescending(s => s.Urgentie);
                    break;

                case "categorie_desc":
                    tickets = tickets.OrderByDescending(s => s.Categorie);
                    break;

                case "subcategorie_desc":
                    tickets = tickets.OrderByDescending(s => s.SubCategorie);
                    break;

                case "status_desc":
                    tickets = tickets.OrderByDescending(s => s.Status);
                    break;

                default:
                    tickets = tickets.OrderByDescending(s => s.Datum);
                    break;

            };


            //return View(await applicationDbContext.ToListAsync());
            return View(await tickets.ToListAsync());
            //return View(model);

        }
        //GET - CREATE
        public IActionResult Create()
        {
            return View(TicketVM);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            TicketVM.Ticket.SubCategorieId = Convert.ToInt32(Request.Form["SubCategorieId"].ToString());

            if (!ModelState.IsValid)
            {
                return View(TicketVM);
            }

            _context.Ticket.Add(TicketVM.Ticket);
            await _context.SaveChangesAsync();

            //Work on the image saving section

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var ticketFromDb = await _context.Ticket.FindAsync(TicketVM.Ticket.Id);

            if (files.Count > 0)
            {
                //files has been uploaded
                var uploads = Path.Combine(webRootPath, "images");
                var extension = Path.GetExtension(files[0].FileName);

                using (var filesStream = new FileStream(Path.Combine(uploads, TicketVM.Ticket.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }
                ticketFromDb.Screenshot = @"\images\" + TicketVM.Ticket.Id + extension;
            }
            else
            {
                //no file was uploaded, so use default
                var uploads = Path.Combine(webRootPath, @"images\" + "websitebg.png"); ;
                System.IO.File.Copy(uploads, webRootPath + @"\images\" + TicketVM.Ticket.Id + ".png");
                ticketFromDb.Screenshot = @"\images\" + TicketVM.Ticket.Id + ".png";
            }

            //stuur een mail
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("HelpdeskIT", "pieterjan.blomme@sgvw.be"));
            message.To.Add(new MailboxAddress("Aanvrager", TicketVM.Ticket.EmailAanvrager));
            message.To.Add(new MailboxAddress("VerantwoordelijkeSchool", _context.School.Where(u => u.Id == TicketVM.Ticket.SchoolId).FirstOrDefault().Verantwoordelijke));
            //message.To.Add(new MailboxAddress("VerantwoordelijkeSchool2", _context.School.Where(u => u.Id == TicketVM.Ticket.SchoolId).FirstOrDefault().Verantwoordelijke2));
            message.To.Add(new MailboxAddress("VerantwoordelijkeCategorie", _context.Categorie.Where(u => u.Id == TicketVM.Ticket.CategorieId).FirstOrDefault().Verantwoordelijke));
            //message.To.Add(new MailboxAddress("VerantwoordelijkeCategorie2", _context.Categorie.Where(u => u.Id == TicketVM.Ticket.CategorieId).FirstOrDefault().Verantwoordelijke2));
            message.To.Add(new MailboxAddress("VerantwoordelijkeSubCategorie", _context.SubCategorie.Where(u => u.Id == TicketVM.Ticket.SubCategorieId).FirstOrDefault().Verantwoordelijke));
            //message.To.Add(new MailboxAddress("VerantwoordelijkeSubCategorie2", _context.SubCategorie.Where(u => u.Id == TicketVM.Ticket.SubCategorieId).FirstOrDefault().Verantwoordelijke2));

            message.Subject = "nieuw helpdeskticket: " + TicketVM.Ticket.Id;
            message.Body = new TextPart("html")
            {
                Text = "Beste collega <p>" +
                "Er is een nieuwe helpdesk-ticket aangemaakt <br>" +
                "<br><b> Ticket-Id: </b>" + TicketVM.Ticket.Id +
                "<br><b> Aanvrager: </b>" + TicketVM.Ticket.Aanvrager +
                "<br><b> Categorie: </b>" + _context.Categorie.Where(u => u.Id == TicketVM.Ticket.CategorieId).FirstOrDefault().Naam +
                "<br><b> Subcategorie: </b>" + _context.SubCategorie.Where(u => u.Id == TicketVM.Ticket.SubCategorieId).FirstOrDefault().Subcategorie +
                "<br><b> School: </b>" + _context.School.Where(u => u.Id == TicketVM.Ticket.SchoolId).FirstOrDefault().Naam +
                "<br><b> Omschrijving: </b><br>" + TicketVM.Ticket.Omschrijving +
                "<p> We volgen het voor u op" +
                "<p>Met vriendelijke groet" +
                "<br> Het IT-team"

            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.office365.com", 587, false);
                client.Authenticate("blmpt@sgvw.be", "ICT8660@immac");
                client.Send(message);
                client.Disconnect(true);
            }



            await _context.SaveChangesAsync();



            return RedirectToAction(nameof(Details), new { id = TicketVM.Ticket.Id.ToString() });

        }

        //GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TicketVM.Ticket = await _context.Ticket.Include(m => m.Categorie).Include(m => m.SubCategorie).SingleOrDefaultAsync(m => m.Id == id);
            TicketVM.SubCategorie = await _context.SubCategorie.Where(s => s.CategorieId == TicketVM.Ticket.CategorieId).ToListAsync();

            if (TicketVM.Ticket == null)
            {
                return NotFound();
            }
            return View(TicketVM);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPOST(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TicketVM.Ticket.SubCategorieId = Convert.ToInt32(Request.Form["SubCategorieId"].ToString());

            if (!ModelState.IsValid)
            {
                TicketVM.SubCategorie = await _context.SubCategorie.Where(s => s.CategorieId == TicketVM.Ticket.CategorieId).ToListAsync();
                return View(TicketVM);
            }

            //Work on the image saving section

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var menuItemFromDb = await _context.Ticket.FindAsync(TicketVM.Ticket.Id);

            if (files.Count > 0)
            {
                //New Image has been uploaded
                var uploads = Path.Combine(webRootPath, "images");
                var extension_new = Path.GetExtension(files[0].FileName);

                //Delete the original file
                var imagePath = Path.Combine(webRootPath, menuItemFromDb.Screenshot.TrimStart('\\'));

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

                //we will upload the new file
                using (var filesStream = new FileStream(Path.Combine(uploads, TicketVM.Ticket.Id + extension_new), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }
                menuItemFromDb.Screenshot = @"\images\" + TicketVM.Ticket.Id + extension_new;
            }

            menuItemFromDb.Datum = TicketVM.Ticket.Datum;
            menuItemFromDb.Omschrijving = TicketVM.Ticket.Omschrijving;
            menuItemFromDb.Urgentie = TicketVM.Ticket.Urgentie;

            menuItemFromDb.CategorieId = TicketVM.Ticket.CategorieId;
            menuItemFromDb.SubCategorieId = TicketVM.Ticket.SubCategorieId;
            menuItemFromDb.SchoolId = TicketVM.Ticket.SchoolId;
            menuItemFromDb.Lokaal = TicketVM.Ticket.Lokaal;
            menuItemFromDb.Aanvrager = TicketVM.Ticket.Aanvrager;
            if (User.IsInRole("Manager"))
            {
                menuItemFromDb.Status = TicketVM.Ticket.Status;
                menuItemFromDb.Opvolger = TicketVM.Ticket.Opvolger;
                menuItemFromDb.Uitleg = TicketVM.Ticket.Uitleg;
            }

            //stuur een mail
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("HelpdeskIT", "pieterjan.blomme@sgvw.be"));
            message.To.Add(new MailboxAddress("Aanvrager", TicketVM.Ticket.EmailAanvrager));
            message.To.Add(new MailboxAddress("VerantwoordelijkeSchool", _context.School.Where(u => u.Id == TicketVM.Ticket.SchoolId).FirstOrDefault().Verantwoordelijke));
            //message.To.Add(new MailboxAddress("VerantwoordelijkeSchool2", _context.School.Where(u => u.Id == TicketVM.Ticket.SchoolId).FirstOrDefault().Verantwoordelijke2));
            message.To.Add(new MailboxAddress("VerantwoordelijkeCategorie", _context.Categorie.Where(u => u.Id == TicketVM.Ticket.CategorieId).FirstOrDefault().Verantwoordelijke));
            //message.To.Add(new MailboxAddress("VerantwoordelijkeCategorie2", _context.Categorie.Where(u => u.Id == TicketVM.Ticket.CategorieId).FirstOrDefault().Verantwoordelijke2));
            message.To.Add(new MailboxAddress("VerantwoordelijkeSubCategorie", _context.SubCategorie.Where(u => u.Id == TicketVM.Ticket.SubCategorieId).FirstOrDefault().Verantwoordelijke));
            //message.To.Add(new MailboxAddress("VerantwoordelijkeSubCategorie2", _context.SubCategorie.Where(u => u.Id == TicketVM.Ticket.SubCategorieId).FirstOrDefault().Verantwoordelijke2));


            message.Subject = "Het ticket met Ticket-Id " + TicketVM.Ticket.Id + " werd bewerkt!";
            message.Body = new TextPart("html")
            {
                Text = "Beste collega <p>" +
                "Uw ticket werd bewerkt: <br>" +
                "<br><b> Ticket-Id: </b>" + TicketVM.Ticket.Id +
                "<br><b> Aanvrager: </b>" + TicketVM.Ticket.Aanvrager +
                "<br><b> Categorie: </b>" + _context.Categorie.Where(u => u.Id == TicketVM.Ticket.CategorieId).FirstOrDefault().Naam +
                "<br><b> Subcategorie: </b>" + _context.SubCategorie.Where(u => u.Id == TicketVM.Ticket.SubCategorieId).FirstOrDefault().Subcategorie +
                "<br><b> School: </b>" + _context.School.Where(u => u.Id == TicketVM.Ticket.SchoolId).FirstOrDefault().Naam +
                "<br><b> Omschrijving: </b><br>" + TicketVM.Ticket.Omschrijving +
                "<p><br><b> Opvolging: </b><br>" + TicketVM.Ticket.Uitleg +
                "<p>ga naar de helpdesk voor meer info!" +

                "<p>Met vriendelijke groet" +
                "<br> Het IT-team"

            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.office365.com", 587, false);
                client.Authenticate("blmpt@sgvw.be", "ICT8660@immac");
                client.Send(message);
                client.Disconnect(true);
            }


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = TicketVM.Ticket.Id.ToString() });
        }

        // GET: Personeel/Ticket/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .Include(t => t.Categorie)
                .Include(t => t.SubCategorie)
                .Include(t => t.School)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            
            return View(ticket);
        }


        // GET: Personeel/Ticket/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .Include(t => t.Categorie)
                .Include(t => t.School)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Personeel/Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();
 
            if (!User.IsInRole("Manager"))
            {
                return RedirectToAction("Overzicht", "Home", new { area = "Personeel" });
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.Id == id);
        }

        //Archief
        public async Task<IActionResult> IndexArchief(string sortOrder, int zoektermId, string zoektermOmschrijving, string zoektermAanvrager, string zoektermCategorie, string zoektermSchool, string zoektermOpvolger, string zoektermStatus)
        {

            var applicationDbContext = _context.Ticket.Include(m => m.Categorie).Include(m => m.SubCategorie).Include(m => m.School);

            var tickets = from s in _context.Ticket
                          select s;


            if (string.IsNullOrEmpty(zoektermOmschrijving)) { zoektermOmschrijving = ""; };
            if (string.IsNullOrEmpty(zoektermAanvrager)) { zoektermAanvrager = ""; };
            if (string.IsNullOrEmpty(zoektermCategorie)) { zoektermCategorie = ""; };
            if (string.IsNullOrEmpty(zoektermSchool)) { zoektermSchool = ""; };
            switch (zoektermOpvolger)
            {
                case "Niemand":
                    zoektermOpvolger = "0";
                    break;
                case "André":
                    zoektermOpvolger = "1";
                    break;
                case "Frederick":
                    zoektermOpvolger = "2";
                    break;
                case "Pieterjan":
                    zoektermOpvolger = "3";
                    break;
                case "Sander":
                    zoektermOpvolger = "4";
                    break;
                case null:
                    zoektermOpvolger = "";
                    break;

            };

            switch (zoektermStatus)
            {
                case "Open":
                    zoektermStatus = "1";
                    break;
                case "Opgevolgd":
                    zoektermStatus = "2";
                    break;
                case "Afgewerkt":
                    zoektermStatus = "3";
                    break;
                case null:
                    zoektermStatus = "";
                    break;

            }

            if (!string.IsNullOrEmpty(zoektermAanvrager) || !string.IsNullOrEmpty(zoektermOmschrijving) || !string.IsNullOrEmpty(zoektermCategorie) || !string.IsNullOrEmpty(zoektermSchool) || !string.IsNullOrEmpty(zoektermOpvolger) || !string.IsNullOrEmpty(zoektermSchool) || !string.IsNullOrEmpty(zoektermStatus))
            {
                tickets =

                    applicationDbContext
                    .Where(s => s.Aanvrager.Contains(zoektermAanvrager))
                    .Where(s => s.Omschrijving.Contains(zoektermOmschrijving))
                    .Where(s => s.Categorie.Naam.Contains(zoektermCategorie))
                    .Where(s => s.School.Naam.Contains(zoektermSchool))
                    .Where(s => s.Opvolger.Contains(zoektermOpvolger))
                    .Where(s => s.Status.Contains(zoektermStatus))
                    .Where(s => s.Status == "3");

                
            }
            else if (zoektermId != 0)
            {
                tickets =

                    applicationDbContext
                    .Where(s => s.Id.Equals(zoektermId));
            }
            else
            {
                tickets = applicationDbContext;
            }

            TicketVM.Aantal = tickets.Count();
            return View(await tickets.ToListAsync());


        }
    }
}

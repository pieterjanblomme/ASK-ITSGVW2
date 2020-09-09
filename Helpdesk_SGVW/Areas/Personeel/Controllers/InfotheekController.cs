using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Helpdesk_SGVW.Data;
using Helpdesk_SGVW.Models;
using Microsoft.AspNetCore.Hosting;
using Helpdesk_SGVW.Models.ViewModel;

namespace Helpdesk_SGVW.Areas.Personeel.Controllers
{
    [Area("Personeel")]
    public class InfotheekController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        [BindProperty]
        public InfotheekViewModel InfotheekVM { get; set; }

        public InfotheekController(ApplicationDbContext db, IWebHostEnvironment hostingEnvironment)
        {
            _context = db;
            _hostingEnvironment = hostingEnvironment;

            InfotheekVM = new InfotheekViewModel()
            {
                Categorie = _context.Categorie,

                Infotheek = new Infotheek(),
            };

        }

        // GET: Personeel/Infotheek
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Infotheek.Include(i => i.Categorie).Include(i => i.SubCategorie);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Personeel/Infotheek/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infotheek = await _context.Infotheek
                .Include(i => i.Categorie)
                .Include(i => i.SubCategorie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (infotheek == null)
            {
                return NotFound();
            }

            return View(infotheek);
        }

        // GET: Personeel/Infotheek/Create
        public IActionResult Create()
        {
            //ViewData["CategorieId"] = new SelectList(_context.Categorie, "Id", "Naam");
            //ViewData["SubCategorieId"] = new SelectList(_context.SubCategorie, "Id", "Subcategorie");
            return View(InfotheekVM);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            InfotheekVM.Infotheek.SubCategorieId = Convert.ToInt32(Request.Form["SubCategorieId"].ToString());

            if (!ModelState.IsValid)
            {
                return View(InfotheekVM);
            }

            _context.Infotheek.Add(InfotheekVM.Infotheek);
            await _context.SaveChangesAsync();

           

           
            await _context.SaveChangesAsync();



            return RedirectToAction(nameof(Details), new { id = InfotheekVM.Infotheek.Id.ToString() });

        }

        

        // GET: Personeel/Infotheek/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infotheek = await _context.Infotheek.FindAsync(id);
            if (infotheek == null)
            {
                return NotFound();
            }
            ViewData["CategorieId"] = new SelectList(_context.Categorie, "Id", "Naam", infotheek.CategorieId);
            ViewData["SubCategorieId"] = new SelectList(_context.SubCategorie, "Id", "Subcategorie", infotheek.SubCategorieId);
            return View(infotheek);
        }

        // POST: Personeel/Infotheek/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titel,Omschrijving,CategorieId,SubCategorieId,Type,Tag1,Tag2,Tag3,Url")] Infotheek infotheek)
        {
            if (id != infotheek.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(infotheek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfotheekExists(infotheek.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategorieId"] = new SelectList(_context.Categorie, "Id", "Naam", infotheek.CategorieId);
            ViewData["SubCategorieId"] = new SelectList(_context.SubCategorie, "Id", "Subcategorie", infotheek.SubCategorieId);
            return View(infotheek);
        }

        // GET: Personeel/Infotheek/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infotheek = await _context.Infotheek
                .Include(i => i.Categorie)
                .Include(i => i.SubCategorie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (infotheek == null)
            {
                return NotFound();
            }

            return View(infotheek);
        }

        // POST: Personeel/Infotheek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var infotheek = await _context.Infotheek.FindAsync(id);
            _context.Infotheek.Remove(infotheek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfotheekExists(int id)
        {
            return _context.Infotheek.Any(e => e.Id == id);
        }
    }
}

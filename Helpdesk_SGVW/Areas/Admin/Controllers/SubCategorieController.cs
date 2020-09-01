using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Helpdesk_SGVW.Data;
using Helpdesk_SGVW.Models;
using Helpdesk_SGVW.Models.ViewModel;

namespace Helpdesk_SGVW.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategorieController : Controller
    {
        private readonly ApplicationDbContext _context;
        public string StatusBericht { get; set; }

        public SubCategorieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/SubCategorie
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SubCategorie.Include(s => s.Categorie);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/SubCategorie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategorie = await _context.SubCategorie
                .Include(s => s.Categorie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subCategorie == null)
            {
                return NotFound();
            }

            return View(subCategorie);
        }

        //GET- CREATE
        public async Task<IActionResult> Create()
        {
            SubCategorieEnCategorieViewModel model = new SubCategorieEnCategorieViewModel()
            {
                CategorieLijst = await _context.Categorie.ToListAsync(),
                SubCategorie = new Models.SubCategorie(),
                SubCategorieLijst = await _context.SubCategorie.OrderBy(p => p.Subcategorie).Select(p => p.Subcategorie).Distinct().ToListAsync()
            };

            return View(model);
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubCategorieEnCategorieViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doesSubCategorieExists = _context.SubCategorie.Include(s => s.Categorie).Where(s => s.Subcategorie == model.SubCategorie.Subcategorie && s.Categorie.Id == model.SubCategorie.CategorieId);

                if (doesSubCategorieExists.Count() > 0)
                {
                    //Error
                    StatusBericht = "Foutmelding : Sub-Categorie bestaat reeds onder categorie " + doesSubCategorieExists.First().Categorie.Naam + ". Kies een andere naam aub.";
                }
                else
                {
                    _context.SubCategorie.Add(model.SubCategorie);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            SubCategorieEnCategorieViewModel modelVM = new SubCategorieEnCategorieViewModel()
            {
                CategorieLijst = await _context.Categorie.ToListAsync(),
                SubCategorie = model.SubCategorie,
                SubCategorieLijst = await _context.SubCategorie.OrderBy(p => p.Subcategorie).Select(p => p.Subcategorie).ToListAsync(),
                StatusBericht = StatusBericht
            };
            return View(modelVM);
        }


        [ActionName("GetSubCategorie")]
        public async Task<IActionResult> GetSubCategorie(int id)
        {
            List<SubCategorie> subCategories = new List<SubCategorie>();

            subCategories = await (from subCategorie in _context.SubCategorie
                                   where subCategorie.CategorieId == id
                                   select subCategorie).ToListAsync();
            return Json(new SelectList(subCategories, "Id", "Subcategorie"));
        }


        // GET: Admin/SubCategorie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategorie = await _context.SubCategorie.FindAsync(id);
            if (subCategorie == null)
            {
                return NotFound();
            }
            ViewData["CategorieId"] = new SelectList(_context.Categorie, "Id", "Naam", subCategorie.CategorieId);
            return View(subCategorie);
        }

        // POST: Admin/SubCategorie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subcategorie,CategorieId,Verantwoordelijke,Verantwoordelijke2")] SubCategorie subCat)
        {
            if (id != subCat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subCat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubCategorieExists(subCat.Id))
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
            ViewData["CategorieId"] = new SelectList(_context.Categorie, "Id", "Naam", subCat.CategorieId);
            return View(subCat);
        }

        // GET: Admin/SubCategorie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategorie = await _context.SubCategorie
                .Include(s => s.Categorie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subCategorie == null)
            {
                return NotFound();
            }

            return View(subCategorie);
        }

        // POST: Admin/SubCategorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subCategorie = await _context.SubCategorie.FindAsync(id);
            _context.SubCategorie.Remove(subCategorie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubCategorieExists(int id)
        {
            return _context.SubCategorie.Any(e => e.Id == id);
        }
    }
}

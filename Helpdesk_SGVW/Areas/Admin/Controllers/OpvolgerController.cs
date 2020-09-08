//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Helpdesk_SGVW.Data;
//using Helpdesk_SGVW.Models;

//namespace Helpdesk_SGVW.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    public class OpvolgerController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public OpvolgerController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        GET: Admin/Opvolger
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Opvolgers.ToListAsync());
//        }

//        GET: Admin/Opvolger/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var opvolgers = await _context.Opvolgers
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (opvolgers == null)
//            {
//                return NotFound();
//            }

//            return View(opvolgers);
//        }

//        GET: Admin/Opvolger/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        POST: Admin/Opvolger/Create
//        To protect from overposting attacks, enable the specific properties you want to bind to, for 
//         more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Voornaam,Familienaam,Displaynaam,Email")] Opvolgers opvolgers)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(opvolgers);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(opvolgers);
//        }

//        GET: Admin/Opvolger/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var opvolgers = await _context.Opvolgers.FindAsync(id);
//            if (opvolgers == null)
//            {
//                return NotFound();
//            }
//            return View(opvolgers);
//        }

//        POST: Admin/Opvolger/Edit/5
//         To protect from overposting attacks, enable the specific properties you want to bind to, for 
//         more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Voornaam,Familienaam,Displaynaam,Email")] Opvolgers opvolgers)
//        {
//            if (id != opvolgers.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(opvolgers);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!OpvolgersExists(opvolgers.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(opvolgers);
//        }

//        GET: Admin/Opvolger/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var opvolgers = await _context.Opvolgers
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (opvolgers == null)
//            {
//                return NotFound();
//            }

//            return View(opvolgers);
//        }

//        POST: Admin/Opvolger/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var opvolgers = await _context.Opvolgers.FindAsync(id);
//            _context.Opvolgers.Remove(opvolgers);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool OpvolgersExists(int id)
//        {
//            return _context.Opvolgers.Any(e => e.Id == id);
//        }
//    }
//}

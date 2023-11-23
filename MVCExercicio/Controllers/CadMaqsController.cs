using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCExercicio.Data;
using MVCExercicio.Models;

namespace MVCExercicio.Controllers
{
    public class CadMaqsController : Controller
    {
        private readonly DBContext _context;

        public CadMaqsController(DBContext context)
        {
            _context = context;
        }

        // GET: CadMaqs
        public async Task<IActionResult> Index()
        {
              return _context.CadMaq != null ? 
                          View(await _context.CadMaq.ToListAsync()) :
                          Problem("Entity set 'DBContext.CadMaq'  is null.");
        }

        // GET: CadMaqs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CadMaq == null)
            {
                return NotFound();
            }

            var cadMaq = await _context.CadMaq
                .FirstOrDefaultAsync(m => m.idMaq == id);
            if (cadMaq == null)
            {
                return NotFound();
            }

            return View(cadMaq);
        }

        // GET: CadMaqs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadMaqs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idMaq,Maquina")] CadMaq cadMaq)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadMaq);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadMaq);
        }

        // GET: CadMaqs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CadMaq == null)
            {
                return NotFound();
            }

            var cadMaq = await _context.CadMaq.FindAsync(id);
            if (cadMaq == null)
            {
                return NotFound();
            }
            return View(cadMaq);
        }

        // POST: CadMaqs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idMaq,Maquina")] CadMaq cadMaq)
        {
            if (id != cadMaq.idMaq)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadMaq);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadMaqExists(cadMaq.idMaq))
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
            return View(cadMaq);
        }

        // GET: CadMaqs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CadMaq == null)
            {
                return NotFound();
            }

            var cadMaq = await _context.CadMaq
                .FirstOrDefaultAsync(m => m.idMaq == id);
            if (cadMaq == null)
            {
                return NotFound();
            }

            return View(cadMaq);
        }

        // POST: CadMaqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CadMaq == null)
            {
                return Problem("Entity set 'DBContext.CadMaq'  is null.");
            }
            var cadMaq = await _context.CadMaq.FindAsync(id);
            if (cadMaq != null)
            {
                _context.CadMaq.Remove(cadMaq);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadMaqExists(int id)
        {
          return (_context.CadMaq?.Any(e => e.idMaq == id)).GetValueOrDefault();
        }
    }
}

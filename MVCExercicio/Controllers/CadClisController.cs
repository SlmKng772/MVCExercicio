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
    public class CadClisController : Controller
    {
        private readonly DBContext _context;

        public CadClisController(DBContext context)
        {
            _context = context;
        }

        // GET: CadClis
        public async Task<IActionResult> Index()
        {
              return _context.CadCli != null ? 
                          View(await _context.CadCli.ToListAsync()) :
                          Problem("Entity set 'DBContext.CadCli'  is null.");
        }

        // GET: CadClis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CadCli == null)
            {
                return NotFound();
            }

            var cadCli = await _context.CadCli
                .FirstOrDefaultAsync(m => m.idCli == id);
            if (cadCli == null)
            {
                return NotFound();
            }

            return View(cadCli);
        }

        // GET: CadClis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadClis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCli,Nome,CPF")] CadCli cadCli)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadCli);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadCli);
        }

        // GET: CadClis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CadCli == null)
            {
                return NotFound();
            }

            var cadCli = await _context.CadCli.FindAsync(id);
            if (cadCli == null)
            {
                return NotFound();
            }
            return View(cadCli);
        }

        // POST: CadClis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCli,Nome,CPF")] CadCli cadCli)
        {
            if (id != cadCli.idCli)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadCli);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadCliExists(cadCli.idCli))
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
            return View(cadCli);
        }

        // GET: CadClis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CadCli == null)
            {
                return NotFound();
            }

            var cadCli = await _context.CadCli
                .FirstOrDefaultAsync(m => m.idCli == id);
            if (cadCli == null)
            {
                return NotFound();
            }

            return View(cadCli);
        }

        // POST: CadClis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CadCli == null)
            {
                return Problem("Entity set 'DBContext.CadCli'  is null.");
            }
            var cadCli = await _context.CadCli.FindAsync(id);
            if (cadCli != null)
            {
                _context.CadCli.Remove(cadCli);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadCliExists(int id)
        {
          return (_context.CadCli?.Any(e => e.idCli == id)).GetValueOrDefault();
        }
    }
}

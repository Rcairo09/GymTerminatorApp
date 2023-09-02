using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymTerminatorApp.Models;

namespace GymTerminatorApp.Controllers
{
    public class MembresiumController : Controller
    {
        private readonly GymAppContext _context;

        public MembresiumController(GymAppContext context)
        {
            _context = context;
        }

        // GET: Membresium
        public async Task<IActionResult> Index()
        {
              return _context.Membresia != null ? 
                          View(await _context.Membresia.ToListAsync()) :
                          Problem("Entity set 'GymAppContext.Membresia'  is null.");
        }

        // GET: Membresium/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Membresia == null)
            {
                return NotFound();
            }

            var membresium = await _context.Membresia
                .FirstOrDefaultAsync(m => m.MembresiaId == id);
            if (membresium == null)
            {
                return NotFound();
            }

            return View(membresium);
        }

        // GET: Membresium/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Membresium/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MembresiaId,Nombre,Precio,Duracion,UnidadDuracion,Descripcion")] Membresium membresium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membresium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membresium);
        }

        // GET: Membresium/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Membresia == null)
            {
                return NotFound();
            }

            var membresium = await _context.Membresia.FindAsync(id);
            if (membresium == null)
            {
                return NotFound();
            }
            return View(membresium);
        }

        // POST: Membresium/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MembresiaId,Nombre,Precio,Duracion,UnidadDuracion,Descripcion")] Membresium membresium)
        {
            if (id != membresium.MembresiaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membresium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembresiumExists(membresium.MembresiaId))
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
            return View(membresium);
        }

        // GET: Membresium/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Membresia == null)
            {
                return NotFound();
            }

            var membresium = await _context.Membresia
                .FirstOrDefaultAsync(m => m.MembresiaId == id);
            if (membresium == null)
            {
                return NotFound();
            }

            return View(membresium);
        }

        // POST: Membresium/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Membresia == null)
            {
                return Problem("Entity set 'GymAppContext.Membresia'  is null.");
            }
            var membresium = await _context.Membresia.FindAsync(id);
            if (membresium != null)
            {
                _context.Membresia.Remove(membresium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembresiumExists(int id)
        {
          return (_context.Membresia?.Any(e => e.MembresiaId == id)).GetValueOrDefault();
        }
    }
}

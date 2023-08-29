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
    public class MiembrosController : Controller
    {
        private readonly GymAppContext _context;

        public MiembrosController(GymAppContext context)
        {
            _context = context;
        }

        // GET: Miembros
        public async Task<IActionResult> Index()
        {
            var gymAppContext = _context.Miembros.Include(m => m.Membresia);
            return View(await gymAppContext.ToListAsync());
        }

        // GET: Miembros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Miembros == null)
            {
                return NotFound();
            }

            var miembro = await _context.Miembros
                .Include(m => m.Membresia)
                .FirstOrDefaultAsync(m => m.MiembroId == id);
            if (miembro == null)
            {
                return NotFound();
            }

            return View(miembro);
        }

        // GET: Miembros/Create
        public IActionResult Create()
        {
            ViewData["MembresiaId"] = new SelectList(_context.Membresia, "MembresiaId", "MembresiaId");
            return View();
        }

        // POST: Miembros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MiembroId,Nombre,Apellido,MembresiaId")] Miembro miembro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(miembro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MembresiaId"] = new SelectList(_context.Membresia, "MembresiaId", "MembresiaId", miembro.MembresiaId);
            return View(miembro);
        }

        // GET: Miembros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Miembros == null)
            {
                return NotFound();
            }

            var miembro = await _context.Miembros.FindAsync(id);
            if (miembro == null)
            {
                return NotFound();
            }
            ViewData["MembresiaId"] = new SelectList(_context.Membresia, "MembresiaId", "MembresiaId", miembro.MembresiaId);
            return View(miembro);
        }

        // POST: Miembros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MiembroId,Nombre,Apellido,MembresiaId")] Miembro miembro)
        {
            if (id != miembro.MiembroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miembro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiembroExists(miembro.MiembroId))
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
            ViewData["MembresiaId"] = new SelectList(_context.Membresia, "MembresiaId", "MembresiaId", miembro.MembresiaId);
            return View(miembro);
        }

        // GET: Miembros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Miembros == null)
            {
                return NotFound();
            }

            var miembro = await _context.Miembros
                .Include(m => m.Membresia)
                .FirstOrDefaultAsync(m => m.MiembroId == id);
            if (miembro == null)
            {
                return NotFound();
            }

            return View(miembro);
        }

        // POST: Miembros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Miembros == null)
            {
                return Problem("Entity set 'GymAppContext.Miembros'  is null.");
            }
            var miembro = await _context.Miembros.FindAsync(id);
            if (miembro != null)
            {
                _context.Miembros.Remove(miembro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiembroExists(int id)
        {
          return (_context.Miembros?.Any(e => e.MiembroId == id)).GetValueOrDefault();
        }
    }
}

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
    public class EntrenadorController : Controller
    {
        private readonly GymAppContext _context;

        public EntrenadorController(GymAppContext context)
        {
            _context = context;
        }

        // GET: Entrenador
        public async Task<IActionResult> Index()
        {
            var gymAppContext = _context.Entrenadors.Include(e => e.Especialidad);
            return View(await gymAppContext.ToListAsync());
        }

        // GET: Entrenador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Entrenadors == null)
            {
                return NotFound();
            }

            var entrenador = await _context.Entrenadors
                .Include(e => e.Especialidad)
                .FirstOrDefaultAsync(m => m.EntrenadorId == id);
            if (entrenador == null)
            {
                return NotFound();
            }

            return View(entrenador);
        }

        // GET: Entrenador/Create
        public IActionResult Create()
        {
            ViewData["EspecialidadId"] = new SelectList(_context.Especialidads, "EspecialidadId", "EspecialidadId");
            return View();
        }

        // POST: Entrenador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntrenadorId,Nombre,EspecialidadId")] Entrenador entrenador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entrenador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecialidadId"] = new SelectList(_context.Especialidads, "EspecialidadId", "EspecialidadId", entrenador.EspecialidadId);
            return View(entrenador);
        }

        // GET: Entrenador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Entrenadors == null)
            {
                return NotFound();
            }

            var entrenador = await _context.Entrenadors.FindAsync(id);
            if (entrenador == null)
            {
                return NotFound();
            }
            ViewData["EspecialidadId"] = new SelectList(_context.Especialidads, "EspecialidadId", "EspecialidadId", entrenador.EspecialidadId);
            return View(entrenador);
        }

        // POST: Entrenador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntrenadorId,Nombre,EspecialidadId")] Entrenador entrenador)
        {
            if (id != entrenador.EntrenadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entrenador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntrenadorExists(entrenador.EntrenadorId))
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
            ViewData["EspecialidadId"] = new SelectList(_context.Especialidads, "EspecialidadId", "EspecialidadId", entrenador.EspecialidadId);
            return View(entrenador);
        }

        // GET: Entrenador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Entrenadors == null)
            {
                return NotFound();
            }

            var entrenador = await _context.Entrenadors
                .Include(e => e.Especialidad)
                .FirstOrDefaultAsync(m => m.EntrenadorId == id);
            if (entrenador == null)
            {
                return NotFound();
            }

            return View(entrenador);
        }

        // POST: Entrenador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Entrenadors == null)
            {
                return Problem("Entity set 'GymAppContext.Entrenadors'  is null.");
            }
            var entrenador = await _context.Entrenadors.FindAsync(id);
            if (entrenador != null)
            {
                _context.Entrenadors.Remove(entrenador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntrenadorExists(int id)
        {
          return (_context.Entrenadors?.Any(e => e.EntrenadorId == id)).GetValueOrDefault();
        }
    }
}

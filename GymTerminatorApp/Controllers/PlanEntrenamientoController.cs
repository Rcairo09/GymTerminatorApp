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
    public class PlanEntrenamientoController : Controller
    {
        private readonly GymAppContext _context;

        public PlanEntrenamientoController(GymAppContext context)
        {
            _context = context;
        }

        // GET: PlanEntrenamiento
        public async Task<IActionResult> Index()
        {
            var gymAppContext = _context.PlanEntrenamientos.Include(p => p.Entrenador);
            return View(await gymAppContext.ToListAsync());
        }

        // GET: PlanEntrenamiento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PlanEntrenamientos == null)
            {
                return NotFound();
            }

            var planEntrenamiento = await _context.PlanEntrenamientos
                .Include(p => p.Entrenador)
                .FirstOrDefaultAsync(m => m.PlanEntrenamientoId == id);
            if (planEntrenamiento == null)
            {
                return NotFound();
            }

            return View(planEntrenamiento);
        }

        // GET: PlanEntrenamiento/Create
        public IActionResult Create()
        {
            ViewData["EntrenadorId"] = new SelectList(_context.Entrenadors, "EntrenadorId", "EntrenadorId");
            return View();
        }

        // POST: PlanEntrenamiento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlanEntrenamientoId,Nombre,Descripcion,EntrenadorId")] PlanEntrenamiento planEntrenamiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planEntrenamiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EntrenadorId"] = new SelectList(_context.Entrenadors, "EntrenadorId", "EntrenadorId", planEntrenamiento.EntrenadorId);
            return View(planEntrenamiento);
        }

        // GET: PlanEntrenamiento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PlanEntrenamientos == null)
            {
                return NotFound();
            }

            var planEntrenamiento = await _context.PlanEntrenamientos.FindAsync(id);
            if (planEntrenamiento == null)
            {
                return NotFound();
            }
            ViewData["EntrenadorId"] = new SelectList(_context.Entrenadors, "EntrenadorId", "EntrenadorId", planEntrenamiento.EntrenadorId);
            return View(planEntrenamiento);
        }

        // POST: PlanEntrenamiento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlanEntrenamientoId,Nombre,Descripcion,EntrenadorId")] PlanEntrenamiento planEntrenamiento)
        {
            if (id != planEntrenamiento.PlanEntrenamientoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planEntrenamiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanEntrenamientoExists(planEntrenamiento.PlanEntrenamientoId))
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
            ViewData["EntrenadorId"] = new SelectList(_context.Entrenadors, "EntrenadorId", "EntrenadorId", planEntrenamiento.EntrenadorId);
            return View(planEntrenamiento);
        }

        // GET: PlanEntrenamiento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PlanEntrenamientos == null)
            {
                return NotFound();
            }

            var planEntrenamiento = await _context.PlanEntrenamientos
                .Include(p => p.Entrenador)
                .FirstOrDefaultAsync(m => m.PlanEntrenamientoId == id);
            if (planEntrenamiento == null)
            {
                return NotFound();
            }

            return View(planEntrenamiento);
        }

        // POST: PlanEntrenamiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PlanEntrenamientos == null)
            {
                return Problem("Entity set 'GymAppContext.PlanEntrenamientos'  is null.");
            }
            var planEntrenamiento = await _context.PlanEntrenamientos.FindAsync(id);
            if (planEntrenamiento != null)
            {
                _context.PlanEntrenamientos.Remove(planEntrenamiento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanEntrenamientoExists(int id)
        {
          return (_context.PlanEntrenamientos?.Any(e => e.PlanEntrenamientoId == id)).GetValueOrDefault();
        }
    }
}

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
    public class PlanEntrenamientoEjercicioController : Controller
    {
        private readonly GymAppContext _context;

        public PlanEntrenamientoEjercicioController(GymAppContext context)
        {
            _context = context;
        }

        // GET: PlanEntrenamientoEjercicio
        public async Task<IActionResult> Index()
        {
            var gymAppContext = _context.PlanEntrenamientoEjercicios.Include(p => p.Ejercicio).Include(p => p.PlanEntrenamiento);
            return View(await gymAppContext.ToListAsync());
        }

        // GET: PlanEntrenamientoEjercicio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PlanEntrenamientoEjercicios == null)
            {
                return NotFound();
            }

            var planEntrenamientoEjercicio = await _context.PlanEntrenamientoEjercicios
                .Include(p => p.Ejercicio)
                .Include(p => p.PlanEntrenamiento)
                .FirstOrDefaultAsync(m => m.PlanEntrenamientoEjercicioId == id);
            if (planEntrenamientoEjercicio == null)
            {
                return NotFound();
            }

            return View(planEntrenamientoEjercicio);
        }

        // GET: PlanEntrenamientoEjercicio/Create
        public IActionResult Create()
        {
            ViewData["EjercicioId"] = new SelectList(_context.Ejercicios, "EjercicioId", "EjercicioId");
            ViewData["PlanEntrenamientoId"] = new SelectList(_context.PlanEntrenamientos, "PlanEntrenamientoId", "PlanEntrenamientoId");
            return View();
        }

        // POST: PlanEntrenamientoEjercicio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlanEntrenamientoEjercicioId,PlanEntrenamientoId,EjercicioId")] PlanEntrenamientoEjercicio planEntrenamientoEjercicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planEntrenamientoEjercicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EjercicioId"] = new SelectList(_context.Ejercicios, "EjercicioId", "EjercicioId", planEntrenamientoEjercicio.EjercicioId);
            ViewData["PlanEntrenamientoId"] = new SelectList(_context.PlanEntrenamientos, "PlanEntrenamientoId", "PlanEntrenamientoId", planEntrenamientoEjercicio.PlanEntrenamientoId);
            return View(planEntrenamientoEjercicio);
        }

        // GET: PlanEntrenamientoEjercicio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PlanEntrenamientoEjercicios == null)
            {
                return NotFound();
            }

            var planEntrenamientoEjercicio = await _context.PlanEntrenamientoEjercicios.FindAsync(id);
            if (planEntrenamientoEjercicio == null)
            {
                return NotFound();
            }
            ViewData["EjercicioId"] = new SelectList(_context.Ejercicios, "EjercicioId", "EjercicioId", planEntrenamientoEjercicio.EjercicioId);
            ViewData["PlanEntrenamientoId"] = new SelectList(_context.PlanEntrenamientos, "PlanEntrenamientoId", "PlanEntrenamientoId", planEntrenamientoEjercicio.PlanEntrenamientoId);
            return View(planEntrenamientoEjercicio);
        }

        // POST: PlanEntrenamientoEjercicio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlanEntrenamientoEjercicioId,PlanEntrenamientoId,EjercicioId")] PlanEntrenamientoEjercicio planEntrenamientoEjercicio)
        {
            if (id != planEntrenamientoEjercicio.PlanEntrenamientoEjercicioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planEntrenamientoEjercicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanEntrenamientoEjercicioExists(planEntrenamientoEjercicio.PlanEntrenamientoEjercicioId))
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
            ViewData["EjercicioId"] = new SelectList(_context.Ejercicios, "EjercicioId", "EjercicioId", planEntrenamientoEjercicio.EjercicioId);
            ViewData["PlanEntrenamientoId"] = new SelectList(_context.PlanEntrenamientos, "PlanEntrenamientoId", "PlanEntrenamientoId", planEntrenamientoEjercicio.PlanEntrenamientoId);
            return View(planEntrenamientoEjercicio);
        }

        // GET: PlanEntrenamientoEjercicio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PlanEntrenamientoEjercicios == null)
            {
                return NotFound();
            }

            var planEntrenamientoEjercicio = await _context.PlanEntrenamientoEjercicios
                .Include(p => p.Ejercicio)
                .Include(p => p.PlanEntrenamiento)
                .FirstOrDefaultAsync(m => m.PlanEntrenamientoEjercicioId == id);
            if (planEntrenamientoEjercicio == null)
            {
                return NotFound();
            }

            return View(planEntrenamientoEjercicio);
        }

        // POST: PlanEntrenamientoEjercicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PlanEntrenamientoEjercicios == null)
            {
                return Problem("Entity set 'GymAppContext.PlanEntrenamientoEjercicios'  is null.");
            }
            var planEntrenamientoEjercicio = await _context.PlanEntrenamientoEjercicios.FindAsync(id);
            if (planEntrenamientoEjercicio != null)
            {
                _context.PlanEntrenamientoEjercicios.Remove(planEntrenamientoEjercicio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanEntrenamientoEjercicioExists(int id)
        {
          return (_context.PlanEntrenamientoEjercicios?.Any(e => e.PlanEntrenamientoEjercicioId == id)).GetValueOrDefault();
        }
    }
}

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
    public class PlanEntrenamientoMiembroController : Controller
    {
        private readonly GymAppContext _context;

        public PlanEntrenamientoMiembroController(GymAppContext context)
        {
            _context = context;
        }

        // GET: PlanEntrenamientoMiembro
        public async Task<IActionResult> Index()
        {
            var gymAppContext = _context.PlanEntrenamientoMiembros.Include(p => p.PlanEntrenamiento).Include(p => p.User);
            return View(await gymAppContext.ToListAsync());
        }

        // GET: PlanEntrenamientoMiembro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PlanEntrenamientoMiembros == null)
            {
                return NotFound();
            }

            var planEntrenamientoMiembro = await _context.PlanEntrenamientoMiembros
                .Include(p => p.PlanEntrenamiento)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PlanEntrenamientoMiembroId == id);
            if (planEntrenamientoMiembro == null)
            {
                return NotFound();
            }

            return View(planEntrenamientoMiembro);
        }

        // GET: PlanEntrenamientoMiembro/Create
        public IActionResult Create()
        {
            ViewData["PlanEntrenamientoId"] = new SelectList(_context.PlanEntrenamientos, "PlanEntrenamientoId", "PlanEntrenamientoId");
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: PlanEntrenamientoMiembro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlanEntrenamientoMiembroId,PlanEntrenamientoId,UserId")] PlanEntrenamientoMiembro planEntrenamientoMiembro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planEntrenamientoMiembro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlanEntrenamientoId"] = new SelectList(_context.PlanEntrenamientos, "PlanEntrenamientoId", "PlanEntrenamientoId", planEntrenamientoMiembro.PlanEntrenamientoId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", planEntrenamientoMiembro.UserId);
            return View(planEntrenamientoMiembro);
        }

        // GET: PlanEntrenamientoMiembro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PlanEntrenamientoMiembros == null)
            {
                return NotFound();
            }

            var planEntrenamientoMiembro = await _context.PlanEntrenamientoMiembros.FindAsync(id);
            if (planEntrenamientoMiembro == null)
            {
                return NotFound();
            }
            ViewData["PlanEntrenamientoId"] = new SelectList(_context.PlanEntrenamientos, "PlanEntrenamientoId", "PlanEntrenamientoId", planEntrenamientoMiembro.PlanEntrenamientoId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", planEntrenamientoMiembro.UserId);
            return View(planEntrenamientoMiembro);
        }

        // POST: PlanEntrenamientoMiembro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlanEntrenamientoMiembroId,PlanEntrenamientoId,UserId")] PlanEntrenamientoMiembro planEntrenamientoMiembro)
        {
            if (id != planEntrenamientoMiembro.PlanEntrenamientoMiembroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planEntrenamientoMiembro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanEntrenamientoMiembroExists(planEntrenamientoMiembro.PlanEntrenamientoMiembroId))
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
            ViewData["PlanEntrenamientoId"] = new SelectList(_context.PlanEntrenamientos, "PlanEntrenamientoId", "PlanEntrenamientoId", planEntrenamientoMiembro.PlanEntrenamientoId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", planEntrenamientoMiembro.UserId);
            return View(planEntrenamientoMiembro);
        }

        // GET: PlanEntrenamientoMiembro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PlanEntrenamientoMiembros == null)
            {
                return NotFound();
            }

            var planEntrenamientoMiembro = await _context.PlanEntrenamientoMiembros
                .Include(p => p.PlanEntrenamiento)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PlanEntrenamientoMiembroId == id);
            if (planEntrenamientoMiembro == null)
            {
                return NotFound();
            }

            return View(planEntrenamientoMiembro);
        }

        // POST: PlanEntrenamientoMiembro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PlanEntrenamientoMiembros == null)
            {
                return Problem("Entity set 'GymAppContext.PlanEntrenamientoMiembros'  is null.");
            }
            var planEntrenamientoMiembro = await _context.PlanEntrenamientoMiembros.FindAsync(id);
            if (planEntrenamientoMiembro != null)
            {
                _context.PlanEntrenamientoMiembros.Remove(planEntrenamientoMiembro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanEntrenamientoMiembroExists(int id)
        {
          return (_context.PlanEntrenamientoMiembros?.Any(e => e.PlanEntrenamientoMiembroId == id)).GetValueOrDefault();
        }
    }
}

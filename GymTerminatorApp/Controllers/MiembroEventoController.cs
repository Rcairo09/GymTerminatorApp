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
    public class MiembroEventoController : Controller
    {
        private readonly GymAppContext _context;

        public MiembroEventoController(GymAppContext context)
        {
            _context = context;
        }

        // GET: MiembroEvento
        public async Task<IActionResult> Index()
        {
            var gymAppContext = _context.MiembroEventos.Include(m => m.Evento).Include(m => m.User);
            return View(await gymAppContext.ToListAsync());
        }

        // GET: MiembroEvento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MiembroEventos == null)
            {
                return NotFound();
            }

            var miembroEvento = await _context.MiembroEventos
                .Include(m => m.Evento)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.MiembroEventoId == id);
            if (miembroEvento == null)
            {
                return NotFound();
            }

            return View(miembroEvento);
        }

        // GET: MiembroEvento/Create
        public IActionResult Create()
        {
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "EventoId");
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: MiembroEvento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MiembroEventoId,EventoId,UserId")] MiembroEvento miembroEvento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(miembroEvento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "EventoId", miembroEvento.EventoId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", miembroEvento.UserId);
            return View(miembroEvento);
        }

        // GET: MiembroEvento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MiembroEventos == null)
            {
                return NotFound();
            }

            var miembroEvento = await _context.MiembroEventos.FindAsync(id);
            if (miembroEvento == null)
            {
                return NotFound();
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "EventoId", miembroEvento.EventoId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", miembroEvento.UserId);
            return View(miembroEvento);
        }

        // POST: MiembroEvento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MiembroEventoId,EventoId,UserId")] MiembroEvento miembroEvento)
        {
            if (id != miembroEvento.MiembroEventoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miembroEvento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiembroEventoExists(miembroEvento.MiembroEventoId))
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
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "EventoId", miembroEvento.EventoId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", miembroEvento.UserId);
            return View(miembroEvento);
        }

        // GET: MiembroEvento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MiembroEventos == null)
            {
                return NotFound();
            }

            var miembroEvento = await _context.MiembroEventos
                .Include(m => m.Evento)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.MiembroEventoId == id);
            if (miembroEvento == null)
            {
                return NotFound();
            }

            return View(miembroEvento);
        }

        // POST: MiembroEvento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MiembroEventos == null)
            {
                return Problem("Entity set 'GymAppContext.MiembroEventos'  is null.");
            }
            var miembroEvento = await _context.MiembroEventos.FindAsync(id);
            if (miembroEvento != null)
            {
                _context.MiembroEventos.Remove(miembroEvento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiembroEventoExists(int id)
        {
          return (_context.MiembroEventos?.Any(e => e.MiembroEventoId == id)).GetValueOrDefault();
        }
    }
}

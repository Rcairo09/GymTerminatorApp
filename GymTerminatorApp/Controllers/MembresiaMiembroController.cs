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
    public class MembresiaMiembroController : Controller
    {
        private readonly GymAppContext _context;

        public MembresiaMiembroController(GymAppContext context)
        {
            _context = context;
        }

        // GET: MembresiaMiembro
        public async Task<IActionResult> Index()
        {
            var gymAppContext = _context.MembresiaMiembros.Include(m => m.Membresia).Include(m => m.User);
            return View(await gymAppContext.ToListAsync());
        }

        // GET: MembresiaMiembro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MembresiaMiembros == null)
            {
                return NotFound();
            }

            var membresiaMiembro = await _context.MembresiaMiembros
                .Include(m => m.Membresia)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.MembresiaMiembroId == id);
            if (membresiaMiembro == null)
            {
                return NotFound();
            }

            return View(membresiaMiembro);
        }

        // GET: MembresiaMiembro/Create
        public IActionResult Create()
        {
            ViewData["MembresiaId"] = new SelectList(_context.Membresia, "MembresiaId", "MembresiaId");
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: MembresiaMiembro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MembresiaMiembroId,MembresiaId,FechaAdquisicion,UserId")] MembresiaMiembro membresiaMiembro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membresiaMiembro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MembresiaId"] = new SelectList(_context.Membresia, "MembresiaId", "MembresiaId", membresiaMiembro.MembresiaId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", membresiaMiembro.UserId);
            return View(membresiaMiembro);
        }

        // GET: MembresiaMiembro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MembresiaMiembros == null)
            {
                return NotFound();
            }

            var membresiaMiembro = await _context.MembresiaMiembros.FindAsync(id);
            if (membresiaMiembro == null)
            {
                return NotFound();
            }
            ViewData["MembresiaId"] = new SelectList(_context.Membresia, "MembresiaId", "MembresiaId", membresiaMiembro.MembresiaId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", membresiaMiembro.UserId);
            return View(membresiaMiembro);
        }

        // POST: MembresiaMiembro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MembresiaMiembroId,MembresiaId,FechaAdquisicion,UserId")] MembresiaMiembro membresiaMiembro)
        {
            if (id != membresiaMiembro.MembresiaMiembroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membresiaMiembro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembresiaMiembroExists(membresiaMiembro.MembresiaMiembroId))
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
            ViewData["MembresiaId"] = new SelectList(_context.Membresia, "MembresiaId", "MembresiaId", membresiaMiembro.MembresiaId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", membresiaMiembro.UserId);
            return View(membresiaMiembro);
        }

        // GET: MembresiaMiembro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MembresiaMiembros == null)
            {
                return NotFound();
            }

            var membresiaMiembro = await _context.MembresiaMiembros
                .Include(m => m.Membresia)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.MembresiaMiembroId == id);
            if (membresiaMiembro == null)
            {
                return NotFound();
            }

            return View(membresiaMiembro);
        }

        // POST: MembresiaMiembro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MembresiaMiembros == null)
            {
                return Problem("Entity set 'GymAppContext.MembresiaMiembros'  is null.");
            }
            var membresiaMiembro = await _context.MembresiaMiembros.FindAsync(id);
            if (membresiaMiembro != null)
            {
                _context.MembresiaMiembros.Remove(membresiaMiembro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembresiaMiembroExists(int id)
        {
          return (_context.MembresiaMiembros?.Any(e => e.MembresiaMiembroId == id)).GetValueOrDefault();
        }
    }
}

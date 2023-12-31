﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymTerminatorApp.Models;

namespace GymTerminatorApp.Controllers
{
    public class EjercicioController : Controller
    {
        private readonly GymAppContext _context;

        public EjercicioController(GymAppContext context)
        {
            _context = context;
        }

        // GET: Ejercicio
        public async Task<IActionResult> Index()
        {
              return _context.Ejercicios != null ? 
                          View(await _context.Ejercicios.ToListAsync()) :
                          Problem("Entity set 'GymAppContext.Ejercicios'  is null.");
        }

        // GET: Ejercicio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ejercicios == null)
            {
                return NotFound();
            }

            var ejercicio = await _context.Ejercicios
                .FirstOrDefaultAsync(m => m.EjercicioId == id);
            if (ejercicio == null)
            {
                return NotFound();
            }

            return View(ejercicio);
        }

        // GET: Ejercicio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ejercicio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EjercicioId,Nombre,Descripcion")] Ejercicio ejercicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ejercicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ejercicio);
        }

        // GET: Ejercicio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ejercicios == null)
            {
                return NotFound();
            }

            var ejercicio = await _context.Ejercicios.FindAsync(id);
            if (ejercicio == null)
            {
                return NotFound();
            }
            return View(ejercicio);
        }

        // POST: Ejercicio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EjercicioId,Nombre,Descripcion")] Ejercicio ejercicio)
        {
            if (id != ejercicio.EjercicioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ejercicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EjercicioExists(ejercicio.EjercicioId))
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
            return View(ejercicio);
        }

        // GET: Ejercicio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ejercicios == null)
            {
                return NotFound();
            }

            var ejercicio = await _context.Ejercicios
                .FirstOrDefaultAsync(m => m.EjercicioId == id);
            if (ejercicio == null)
            {
                return NotFound();
            }

            return View(ejercicio);
        }

        // POST: Ejercicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ejercicios == null)
            {
                return Problem("Entity set 'GymAppContext.Ejercicios'  is null.");
            }
            var ejercicio = await _context.Ejercicios.FindAsync(id);
            if (ejercicio != null)
            {
                _context.Ejercicios.Remove(ejercicio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EjercicioExists(int id)
        {
          return (_context.Ejercicios?.Any(e => e.EjercicioId == id)).GetValueOrDefault();
        }
    }
}

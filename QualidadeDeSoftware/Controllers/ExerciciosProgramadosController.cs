using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QualidadeDeSoftware.Data;
using QualidadeDeSoftware.Data.Models;

namespace QualidadeDeSoftware.Controllers
{
    public class ExerciciosProgramadosController : Controller
    {
        private readonly QualidadeDeSoftwareContext _context;

        public ExerciciosProgramadosController(QualidadeDeSoftwareContext context)
        {
            _context = context;
        }

        // GET: ExerciciosProgramados
        public async Task<IActionResult> Index()
        {
              return _context.ExercicioProgramado != null ? 
                          View(await _context.ExercicioProgramado.ToListAsync()) :
                          Problem("Entity set 'QualidadeDeSoftwareContext.ExercicioProgramado'  is null.");
        }

        // GET: ExerciciosProgramados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExercicioProgramado == null)
            {
                return NotFound();
            }

            var exercicioProgramado = await _context.ExercicioProgramado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exercicioProgramado == null)
            {
                return NotFound();
            }

            return View(exercicioProgramado);
        }

        // GET: ExerciciosProgramados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExerciciosProgramados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataLimite")] ExercicioProgramado exercicioProgramado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exercicioProgramado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exercicioProgramado);
        }

        // GET: ExerciciosProgramados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExercicioProgramado == null)
            {
                return NotFound();
            }

            var exercicioProgramado = await _context.ExercicioProgramado.FindAsync(id);
            if (exercicioProgramado == null)
            {
                return NotFound();
            }
            return View(exercicioProgramado);
        }

        // POST: ExerciciosProgramados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataLimite")] ExercicioProgramado exercicioProgramado)
        {
            if (id != exercicioProgramado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exercicioProgramado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExercicioProgramadoExists(exercicioProgramado.Id))
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
            return View(exercicioProgramado);
        }

        // GET: ExerciciosProgramados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExercicioProgramado == null)
            {
                return NotFound();
            }

            var exercicioProgramado = await _context.ExercicioProgramado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exercicioProgramado == null)
            {
                return NotFound();
            }

            return View(exercicioProgramado);
        }

        // POST: ExerciciosProgramados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExercicioProgramado == null)
            {
                return Problem("Entity set 'QualidadeDeSoftwareContext.ExercicioProgramado'  is null.");
            }
            var exercicioProgramado = await _context.ExercicioProgramado.FindAsync(id);
            if (exercicioProgramado != null)
            {
                _context.ExercicioProgramado.Remove(exercicioProgramado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExercicioProgramadoExists(int id)
        {
          return (_context.ExercicioProgramado?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

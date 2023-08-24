using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QualidadeDeSoftware.Data;
using QualidadeDeSoftware.Data.Models;
using QualidadeDeSoftware.ViewObjects;

namespace QualidadeDeSoftware.Controllers
{
    public class ExerciciosController : Controller
    {
        private readonly QualidadeDeSoftwareContext _context;

        public ExerciciosController(QualidadeDeSoftwareContext context)
        {
            _context = context;
        }

        // GET: Exercicios
        public async Task<IActionResult> Index()
        {
            var qualidadeDeSoftwareContext = _context.Exercicio
                .Include(e => e.Aluno)
                .Include(e => e.ExercicioProgramado);
            var exercicios = await qualidadeDeSoftwareContext.ToListAsync();
            return View(exercicios);
        }

        // GET: Exercicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Exercicio == null)
            {
                return NotFound();
            }

            var exercicio = await _context.Exercicio
                .Include(e => e.Aluno)
                .Include(e => e.ExercicioProgramado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exercicio == null)
            {
                return NotFound();
            }

            return View(exercicio);
        }

        public async Task<IActionResult> Create(int alunoId)
        {
            ViewData["ExercicioProgramadoId"] = new SelectList(_context.ExercicioProgramado, "Id", "Nome");

            var aluno = await _context.Aluno.FirstOrDefaultAsync(x => x.Id == alunoId);

            return View(new ExercicioCreateView { AlunoId = alunoId, Aluno = aluno!.Nome, DataEntrega = DateTime.Now.ToString("dd/MM/yyyy") });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataEntrega,EstaAdequado,ExercicioProgramadoId,AlunoId")] ExercicioCreateView exercicioView)
        {
            if (ModelState.IsValid)
            {
                var exercicio = new Exercicio
                {
                    AlunoId = exercicioView.AlunoId,
                    DataEntrega = DateTimeOffset.Parse(exercicioView.DataEntrega),
                    EstaAdequado = exercicioView.EstaAdequado,
                    ExercicioProgramadoId = exercicioView.ExercicioProgramadoId
                };
                _context.Exercicio.Add(exercicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExercicioProgramadoId"] = new SelectList(_context.ExercicioProgramado, "Id", "Nome", exercicioView.ExercicioProgramadoId);
            return View(exercicioView);
        }

        // GET: Exercicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Exercicio == null)
            {
                return NotFound();
            }

            var exercicio = await _context.Exercicio.FindAsync(id);
            if (exercicio == null)
            {
                return NotFound();
            }
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Id", exercicio.AlunoId);
            ViewData["ExercicioProgramadoId"] = new SelectList(_context.ExercicioProgramado, "Id", "Id", exercicio.ExercicioProgramadoId);
            return View(exercicio);
        }

        // POST: Exercicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataEntrega,EstaAdequado,ExercicioProgramadoId,AlunoId")] Exercicio exercicio)
        {
            if (id != exercicio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exercicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExercicioExists(exercicio.Id))
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
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Id", exercicio.AlunoId);
            ViewData["ExercicioProgramadoId"] = new SelectList(_context.ExercicioProgramado, "Id", "Id", exercicio.ExercicioProgramadoId);
            return View(exercicio);
        }

        // GET: Exercicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Exercicio == null)
            {
                return NotFound();
            }

            var exercicio = await _context.Exercicio
                .Include(e => e.Aluno)
                .Include(e => e.ExercicioProgramado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exercicio == null)
            {
                return NotFound();
            }

            return View(exercicio);
        }

        // POST: Exercicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Exercicio == null)
            {
                return Problem("Entity set 'QualidadeDeSoftwareContext.Exercicio'  is null.");
            }
            var exercicio = await _context.Exercicio.FindAsync(id);
            if (exercicio != null)
            {
                _context.Exercicio.Remove(exercicio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExercicioExists(int id)
        {
            return (_context.Exercicio?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
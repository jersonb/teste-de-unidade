using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QualidadeDeSoftware.Data;
using QualidadeDeSoftware.Data.Models;
using QualidadeDeSoftware.ViewObjects;

namespace QualidadeDeSoftware.Controllers
{
    public class ProvasController : Controller
    {
        private readonly QualidadeDeSoftwareContext _context;

        public ProvasController(QualidadeDeSoftwareContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var view = await _context.Prova
                .Include(p => p.Aluno)
                .Select(x => (ProvaIndexView)x)
                .ToListAsync();
            return View(view);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prova == null)
            {
                return NotFound();
            }

            var prova = await _context.Prova
                .Include(p => p.Aluno)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prova == null)
            {
                return NotFound();
            }

            return View(prova);
        }

        public async Task<IActionResult> Create(int alunoId)
        {
            var aluno = await _context.Aluno
                .Select(x => new
                {
                    x.Id,
                    x.Nome
                }).FirstOrDefaultAsync(x => x.Id == alunoId);
            return View(new ProvaCreateView { Aluno = aluno.Nome, AlunoId = aluno.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nota,EhFinal,AlunoId")] ProvaCreateView provaView)
        {
            if (ModelState.IsValid)
            {
                var prova = new Prova
                {
                    AlunoId = provaView.AlunoId,
                    EhFinal = provaView.EhFinal,
                    Nota = decimal.Parse(provaView.Nota),
                };

                _context.Prova.Add(prova);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(provaView);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prova == null)
            {
                return NotFound();
            }

            var prova = await _context.Prova.FindAsync(id);
            if (prova == null)
            {
                return NotFound();
            }
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Id", prova.AlunoId);
            return View(prova);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nota,EhFinal,AlunoId")] Prova prova)
        {
            if (id != prova.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prova);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProvaExists(prova.Id))
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
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Id", prova.AlunoId);
            return View(prova);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prova == null)
            {
                return NotFound();
            }

            var prova = await _context.Prova
                .Include(p => p.Aluno)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prova == null)
            {
                return NotFound();
            }

            return View(prova);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prova == null)
            {
                return Problem("Entity set 'QualidadeDeSoftwareContext.Prova'  is null.");
            }
            var prova = await _context.Prova.FindAsync(id);
            if (prova != null)
            {
                _context.Prova.Remove(prova);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProvaExists(int id)
        {
            return (_context.Prova?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
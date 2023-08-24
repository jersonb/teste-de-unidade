using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QualidadeDeSoftware.Data;
using QualidadeDeSoftware.Data.Models;

namespace QualidadeDeSoftware.Controllers
{
    public class ProvasController : Controller
    {
        private readonly QualidadeDeSoftwareContext _context;

        public ProvasController(QualidadeDeSoftwareContext context)
        {
            _context = context;
        }

        // GET: Provas
        public async Task<IActionResult> Index()
        {
            var qualidadeDeSoftwareContext = _context.Prova
                .Include(p => p.Aluno);
            return View(await qualidadeDeSoftwareContext.ToListAsync());
        }

        // GET: Provas/Details/5
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

        // GET: Provas/Create
        public async Task<IActionResult> Create(int alunoId)
        {
            var aluno = await _context.Aluno.FirstOrDefaultAsync(x => x.Id == alunoId);
            return View(new Prova { Aluno = aluno });
        }

        // POST: Provas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nota,EhFinal,AlunoId")] Prova prova)
        {
            if (ModelState.IsValid)
            {
                prova.Aluno = null;
                _context.Add(prova);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prova);
        }

        // GET: Provas/Edit/5
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

        // POST: Provas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Provas/Delete/5
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

        // POST: Provas/Delete/5
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
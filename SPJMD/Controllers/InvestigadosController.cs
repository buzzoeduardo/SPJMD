using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SPJMD.Data;
using SPJMD.Models;

namespace SPJMD.Controllers
{
    public class InvestigadosController : Controller
    {
        private readonly SPJMDContext _context;

        public InvestigadosController(SPJMDContext context)
        {
            _context = context;
        }

        // GET: Investigados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Investigado.ToListAsync());
        }

        // GET: Investigados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investigado = await _context.Investigado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (investigado == null)
            {
                return NotFound();
            }

            return View(investigado);
        }

        // GET: Investigados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Investigados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Digito,Graduacao,Nome,Status")] Investigado investigado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(investigado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(investigado);
        }

        // GET: Investigados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investigado = await _context.Investigado.FindAsync(id);
            if (investigado == null)
            {
                return NotFound();
            }
            return View(investigado);
        }

        // POST: Investigados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Digito,Graduacao,Nome,Status")] Investigado investigado)
        {
            if (id != investigado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(investigado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvestigadoExists(investigado.Id))
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
            return View(investigado);
        }

        // GET: Investigados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investigado = await _context.Investigado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (investigado == null)
            {
                return NotFound();
            }

            return View(investigado);
        }

        // POST: Investigados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var investigado = await _context.Investigado.FindAsync(id);
            _context.Investigado.Remove(investigado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvestigadoExists(int id)
        {
            return _context.Investigado.Any(e => e.Id == id);
        }
    }
}

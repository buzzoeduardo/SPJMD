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
    public class PoliciaisController : Controller
    {
        private readonly SPJMDContext _context;

        public PoliciaisController(SPJMDContext context)
        {
            _context = context;
        }

        // GET: Policiais
        public async Task<IActionResult> Index()
        {
            return View(await _context.Policial.ToListAsync());
        }

        // GET: Policiais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policial = await _context.Policial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (policial == null)
            {
                return NotFound();
            }

            return View(policial);
        }

        // GET: Policiais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Policiais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Re,Digito,Graduacao,Nome,Status")] Policial policial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(policial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(policial);
        }

        // GET: Policiais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policial = await _context.Policial.FindAsync(id);
            if (policial == null)
            {
                return NotFound();
            }
            return View(policial);
        }

        // POST: Policiais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Re,Digito,Graduacao,Nome,Status")] Policial policial)
        {
            if (id != policial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(policial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PolicialExists(policial.Id))
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
            return View(policial);
        }

        // GET: Policiais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policial = await _context.Policial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (policial == null)
            {
                return NotFound();
            }

            return View(policial);
        }

        // POST: Policiais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var policial = await _context.Policial.FindAsync(id);
            _context.Policial.Remove(policial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PolicialExists(int id)
        {
            return _context.Policial.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP02.Data;
using TP02.Models;

namespace TP02.Controllers
{
    public class ContsController : Controller
    {
        private readonly TP02Context _context;

        public ContsController(TP02Context context)
        {
            _context = context;
        }

        // GET: Conts
        public async Task<IActionResult> Index()
        {
            var tP02Context = _context.Cont.Include(c => c.BL);
            return View(await tP02Context.ToListAsync());
        }

        // GET: Conts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cont = await _context.Cont
                .Include(c => c.BL)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cont == null)
            {
                return NotFound();
            }

            return View(cont);
        }

        // GET: Conts/Create
        public IActionResult Create()
        {
            ViewData["BLId"] = new SelectList(_context.BL, "Id", "Id");
            return View();
        }

        // POST: Conts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,Tipo,Tamanho,BLId")] Cont cont)
        {
            

            if (ModelState.IsValid)
            {
                _context.Add(cont);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            ViewData["BLId"] = new SelectList(_context.BL, "Id", "Id", cont.BLId);
            return View(cont);
        }

        // GET: Conts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cont = await _context.Cont.FindAsync(id);
            if (cont == null)
            {
                return NotFound();
            }
            ViewData["BLId"] = new SelectList(_context.BL, "Id", "Id", cont.BLId);
            return View(cont);
        }

        // POST: Conts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,Tipo,Tamanho,BLId")] Cont cont)
        {
            if (id != cont.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cont);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContExists(cont.Id))
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
            ViewData["BLId"] = new SelectList(_context.BL, "Id", "Id", cont.BLId);
            return View(cont);
        }

        // GET: Conts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cont = await _context.Cont
                .Include(c => c.BL)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cont == null)
            {
                return NotFound();
            }

            return View(cont);
        }

        // POST: Conts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cont = await _context.Cont.FindAsync(id);
            if (cont != null)
            {
                _context.Cont.Remove(cont);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContExists(int id)
        {
            return _context.Cont.Any(e => e.Id == id);
        }
    }
}

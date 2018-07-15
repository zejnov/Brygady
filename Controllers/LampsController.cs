using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Brygady2.Models;

namespace Brygady2.Controllers
{
    public class LampsController : Controller
    {
        private readonly ApplicationContext _context;

        public LampsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Lamps
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Lamps.Include(l => l.ModelLamp);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Lamps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lamps = await _context.Lamps
                .Include(l => l.ModelLamp)
                .FirstOrDefaultAsync(m => m.IdLamp == id);
            if (lamps == null)
            {
                return NotFound();
            }

            return View(lamps);
        }

        // GET: Lamps/Create
        public IActionResult Create()
        {
            ViewData["IdModelLamp"] = new SelectList(_context.ModelLamps, "IdModelLamp", "Name");
            return View();
        }

        // POST: Lamps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLamp,IdModelLamp,Name")] Lamps lamps)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lamps);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdModelLamp"] = new SelectList(_context.ModelLamps, "IdModelLamp", "Name", lamps.IdModelLamp);
            return View(lamps);
        }

        // GET: Lamps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lamps = await _context.Lamps.FindAsync(id);
            if (lamps == null)
            {
                return NotFound();
            }
            ViewData["IdModelLamp"] = new SelectList(_context.ModelLamps, "IdModelLamp", "Name", lamps.IdModelLamp);
            return View(lamps);
        }

        // POST: Lamps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLamp,IdModelLamp,Name")] Lamps lamps)
        {
            if (id != lamps.IdLamp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lamps);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LampsExists(lamps.IdLamp))
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
            ViewData["IdModelLamp"] = new SelectList(_context.ModelLamps, "IdModelLamp", "Name", lamps.IdModelLamp);
            return View(lamps);
        }

        // GET: Lamps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lamps = await _context.Lamps
                .Include(l => l.ModelLamp)
                .FirstOrDefaultAsync(m => m.IdLamp == id);
            if (lamps == null)
            {
                return NotFound();
            }

            return View(lamps);
        }

        // POST: Lamps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lamps = await _context.Lamps.FindAsync(id);
            _context.Lamps.Remove(lamps);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LampsExists(int id)
        {
            return _context.Lamps.Any(e => e.IdLamp == id);
        }
    }
}

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
    public class ModelLampsController : Controller
    {
        private readonly ApplicationContext _context;

        public ModelLampsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: ModelLamps
        public async Task<IActionResult> Index()
        {
            return View(await _context.ModelLamps.ToListAsync());
        }

        // GET: ModelLamps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelLamp = await _context.ModelLamps
                .FirstOrDefaultAsync(m => m.IdModelLamp == id);
            if (modelLamp == null)
            {
                return NotFound();
            }

            return View(modelLamp);
        }

        // GET: ModelLamps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModelLamps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdModelLamp,Name,Comment")] ModelLamp modelLamp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelLamp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelLamp);
        }

        // GET: ModelLamps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelLamp = await _context.ModelLamps.FindAsync(id);
            if (modelLamp == null)
            {
                return NotFound();
            }
            return View(modelLamp);
        }

        // POST: ModelLamps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdModelLamp,Name,Comment")] ModelLamp modelLamp)
        {
            if (id != modelLamp.IdModelLamp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelLamp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelLampExists(modelLamp.IdModelLamp))
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
            return View(modelLamp);
        }

        // GET: ModelLamps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelLamp = await _context.ModelLamps
                .FirstOrDefaultAsync(m => m.IdModelLamp == id);
            if (modelLamp == null)
            {
                return NotFound();
            }

            return View(modelLamp);
        }

        // POST: ModelLamps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modelLamp = await _context.ModelLamps.FindAsync(id);
            _context.ModelLamps.Remove(modelLamp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelLampExists(int id)
        {
            return _context.ModelLamps.Any(e => e.IdModelLamp == id);
        }
    }
}

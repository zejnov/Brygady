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
    public class WorksController : Controller
    {
        private readonly ApplicationContext _context;

        public WorksController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Works
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Works.Include(w => w.SettingBackup);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Works/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var works = await _context.Works
                .Include(w => w.SettingBackup)
                .FirstOrDefaultAsync(m => m.IdWork == id);
            if (works == null)
            {
                return NotFound();
            }

            return View(works);
        }

        // GET: Works/Create
        public IActionResult Create()
        {
            ViewData["IdSettingBackup"] = new SelectList(_context.SettingBackups, "IdSettingBackup", "Comment");
            return View();
        }

        // POST: Works/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdWork,Note,TypeWork,IdSettingBackup,Comment")] Works works)
        {
            if (ModelState.IsValid)
            {
                _context.Add(works);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSettingBackup"] = new SelectList(_context.SettingBackups, "IdSettingBackup", "Comment", works.IdSettingBackup);
            return View(works);
        }

        // GET: Works/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var works = await _context.Works.FindAsync(id);
            if (works == null)
            {
                return NotFound();
            }
            ViewData["IdSettingBackup"] = new SelectList(_context.SettingBackups, "IdSettingBackup", "Comment", works.IdSettingBackup);
            return View(works);
        }

        // POST: Works/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdWork,Note,TypeWork,IdSettingBackup,Comment")] Works works)
        {
            if (id != works.IdWork)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(works);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorksExists(works.IdWork))
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
            ViewData["IdSettingBackup"] = new SelectList(_context.SettingBackups, "IdSettingBackup", "Comment", works.IdSettingBackup);
            return View(works);
        }

        // GET: Works/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var works = await _context.Works
                .Include(w => w.SettingBackup)
                .FirstOrDefaultAsync(m => m.IdWork == id);
            if (works == null)
            {
                return NotFound();
            }

            return View(works);
        }

        // POST: Works/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var works = await _context.Works.FindAsync(id);
            _context.Works.Remove(works);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorksExists(int id)
        {
            return _context.Works.Any(e => e.IdWork == id);
        }
    }
}

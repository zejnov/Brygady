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
    public class SettingBackupsController : Controller
    {
        private readonly ApplicationContext _context;

        public SettingBackupsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: SettingBackups
        public async Task<IActionResult> Index()
        {
            return View(await _context.SettingBackups.ToListAsync());
        }

        // GET: SettingBackups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settingBackups = await _context.SettingBackups
                .FirstOrDefaultAsync(m => m.IdSettingBackup == id);
            if (settingBackups == null)
            {
                return NotFound();
            }

            return View(settingBackups);
        }

        // GET: SettingBackups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SettingBackups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSettingBackup,Time1,Dim1,Time2,Dim2,Time3,Dim3,Batterytype,Dn,Lvd,Comment")] SettingBackups settingBackups)
        {
            if (ModelState.IsValid)
            {
                _context.Add(settingBackups);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(settingBackups);
        }

        // GET: SettingBackups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settingBackups = await _context.SettingBackups.FindAsync(id);
            if (settingBackups == null)
            {
                return NotFound();
            }
            return View(settingBackups);
        }

        // POST: SettingBackups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSettingBackup,Time1,Dim1,Time2,Dim2,Time3,Dim3,Batterytype,Dn,Lvd,Comment")] SettingBackups settingBackups)
        {
            if (id != settingBackups.IdSettingBackup)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(settingBackups);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SettingBackupsExists(settingBackups.IdSettingBackup))
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
            return View(settingBackups);
        }

        // GET: SettingBackups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settingBackups = await _context.SettingBackups
                .FirstOrDefaultAsync(m => m.IdSettingBackup == id);
            if (settingBackups == null)
            {
                return NotFound();
            }

            return View(settingBackups);
        }

        // POST: SettingBackups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var settingBackups = await _context.SettingBackups.FindAsync(id);
            _context.SettingBackups.Remove(settingBackups);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SettingBackupsExists(int id)
        {
            return _context.SettingBackups.Any(e => e.IdSettingBackup == id);
        }
    }
}

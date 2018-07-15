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
    public class GPSsesController : Controller
    {
        private readonly ApplicationContext _context;

        public GPSsesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: GPSses
        public async Task<IActionResult> Index()
        {
            return View(await _context.GPSs.ToListAsync());
        }

        // GET: GPSses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gPSs = await _context.GPSs
                .FirstOrDefaultAsync(m => m.IdGPS == id);
            if (gPSs == null)
            {
                return NotFound();
            }

            return View(gPSs);
        }

        // GET: GPSses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GPSses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGPS,Lat,LON,Ele,Time,Name,Comment")] GPSs gPSs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gPSs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gPSs);
        }

        // GET: GPSses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gPSs = await _context.GPSs.FindAsync(id);
            if (gPSs == null)
            {
                return NotFound();
            }
            return View(gPSs);
        }

        // POST: GPSses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGPS,Lat,LON,Ele,Time,Name,Comment")] GPSs gPSs)
        {
            if (id != gPSs.IdGPS)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gPSs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GPSsExists(gPSs.IdGPS))
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
            return View(gPSs);
        }

        // GET: GPSses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gPSs = await _context.GPSs
                .FirstOrDefaultAsync(m => m.IdGPS == id);
            if (gPSs == null)
            {
                return NotFound();
            }

            return View(gPSs);
        }

        // POST: GPSses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gPSs = await _context.GPSs.FindAsync(id);
            _context.GPSs.Remove(gPSs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GPSsExists(int id)
        {
            return _context.GPSs.Any(e => e.IdGPS == id);
        }
    }
}

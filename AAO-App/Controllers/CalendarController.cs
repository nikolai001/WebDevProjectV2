using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AAO_App.Data;
using AAO_App.Models;

namespace AAO_App.Controllers
{
    public class CalendarController : Controller
    { 
        private readonly ApplicationDbContext _db;

        public CalendarController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Calendar
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _db.Availabilities.Include(a => a.Drivers);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Calendar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availability = await _db.Availabilities
                //.Include(a => a.AvailabilityTypes)
                .Include(a => a.Drivers)
                .FirstOrDefaultAsync(m => m.AvailabilityId == id);
            if (availability == null)
            {
                return NotFound();
            }

            return View(availability);
        }

        // GET: Calendar/Create
        public IActionResult Create()
        {
            //ViewData["AvailabilityTypeId"] = new SelectList(_db.AvailabilityTypes, "AvailabilityTypeId", "AvailabilityTypeId");
            ViewData["DriverId"] = new SelectList(_db.Drivers, "DriverId", "DriverId");
            return View();
        }

        // POST: Calendar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AvailabilityId,DriverId,AvailabilityTypeId,Start,End")] Availability availability)
        {
            if (ModelState.IsValid)
            {
                _db.Add(availability);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           // ViewData["AvailabilityTypeId"] = new SelectList(_db.AvailabilityTypes, "AvailabilityTypeId", "AvailabilityTypeId", availability.AvailabilityTypeId);
            ViewData["DriverId"] = new SelectList(_db.Drivers, "DriverId", "DriverId", availability.DriverId);
            return View(availability);
        }

        // GET: Calendar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availability = await _db.Availabilities.FindAsync(id);
            if (availability == null)
            {
                return NotFound();
            }
           // ViewData["AvailabilityTypeId"] = new SelectList(_db.AvailabilityTypes, "AvailabilityTypeId", "AvailabilityTypeId", availability.AvailabilityTypeId);
            ViewData["DriverId"] = new SelectList(_db.Drivers, "DriverId", "DriverId", availability.DriverId);
            return View(availability);
        }

        // POST: Calendar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AvailabilityId,DriverId,AvailabilityTypeId,Start,End")] Availability availability)
        {
            if (id != availability.AvailabilityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(availability);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvailabilityExists(availability.AvailabilityId))
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
            //ViewData["AvailabilityTypeId"] = new SelectList(_db.AvailabilityTypes, "AvailabilityTypeId", "AvailabilityTypeId", availability.AvailabilityTypeId);
            ViewData["DriverId"] = new SelectList(_db.Drivers, "DriverId", "DriverId", availability.DriverId);
            return View(availability);
        }

        // GET: Calendar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availability = await _db.Availabilities
               // .Include(a => a.AvailabilityTypes)
                .Include(a => a.Drivers)
                .FirstOrDefaultAsync(m => m.AvailabilityId == id);
            if (availability == null)
            {
                return NotFound();
            }

            return View(availability);
        }

        // POST: Calendar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var availability = await _db.Availabilities.FindAsync(id);
            _db.Availabilities.Remove(availability);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvailabilityExists(int id)
        {
            return _db.Availabilities.Any(e => e.AvailabilityId == id);
        }
    }
}

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
    public class DriverHasTripsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DriverHasTripsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DriverHasTrips
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DriverHasTrips.Include(d => d.Drivers);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DriverHasTrips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverHasTrip = await _context.DriverHasTrips
                .Include(d => d.Drivers)
                .FirstOrDefaultAsync(m => m.DriverHasTripId == id);
            if (driverHasTrip == null)
            {
                return NotFound();
            }

            return View(driverHasTrip);
        }

        // GET: DriverHasTrips/Create
        public IActionResult Create()
        {
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId");
            return View();
        }

        // POST: DriverHasTrips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DriverHasTripId,DriverId,TripId,RequestStatus")] DriverHasTrip driverHasTrip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(driverHasTrip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId", driverHasTrip.DriverId);
            return View(driverHasTrip);
        }

        // GET: DriverHasTrips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverHasTrip = await _context.DriverHasTrips.FindAsync(id);
            if (driverHasTrip == null)
            {
                return NotFound();
            }
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId", driverHasTrip.DriverId);
            return View(driverHasTrip);
        }

        // POST: DriverHasTrips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DriverHasTripId,DriverId,TripId,RequestStatus")] DriverHasTrip driverHasTrip)
        {
            if (id != driverHasTrip.DriverHasTripId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driverHasTrip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverHasTripExists(driverHasTrip.DriverHasTripId))
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
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId", driverHasTrip.DriverId);
            return View(driverHasTrip);
        }

        // GET: DriverHasTrips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverHasTrip = await _context.DriverHasTrips
                .Include(d => d.Drivers)
                .FirstOrDefaultAsync(m => m.DriverHasTripId == id);
            if (driverHasTrip == null)
            {
                return NotFound();
            }

            return View(driverHasTrip);
        }

        // POST: DriverHasTrips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var driverHasTrip = await _context.DriverHasTrips.FindAsync(id);
            _context.DriverHasTrips.Remove(driverHasTrip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverHasTripExists(int id)
        {
            return _context.DriverHasTrips.Any(e => e.DriverHasTripId == id);
        }
    }
}

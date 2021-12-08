using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AAO_App.Data;
using AAO_App.Models;

namespace AAO_App
{
    public class TripController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TripController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Trip
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _db.Trips.Include(t => t.Cities.Countries).Include(t => t.Employees);//Include(t => t.Drivers); 
            return View(await applicationDbContext.ToListAsync()); 
        }
        
         
        /*

        // GET: Trip/Details/5
        public async Task<IActionResult> Details(int? id)
        {
        ''
        '

            if (id == null)
            {
                return NotFound();
            }

            var trip = await _db.Trips
                .Include(t => t.Cities)
                .Include(t => t.Drivers)
                .FirstOrDefaultAsync(m => m.TripId == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // GET: Trip/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_db.Cities, "CityId", "CityId");
            ViewData["DriverId"] = new SelectList(_db.Drivers, "DriverId", "DriverId");
            return View();
        }

        // POST: Trip/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TripId,DriverId,CityId,EmpId,DateStart,DateEnd,MessageContents,TripInfo,DriverBuddy")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                _db.Add(trip);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_db.Cities, "CityId", "CityId", trip.CityId);
            ViewData["DriverId"] = new SelectList(_db.Drivers, "DriverId", "DriverId", trip.DriverId);
            return View(trip);
        }

        // GET: Trip/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _db.Trips.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_db.Cities, "CityId", "CityId", trip.CityId);
            ViewData["DriverId"] = new SelectList(_db.Drivers, "DriverId", "DriverId", trip.DriverId);
            return View(trip);
        }

        // POST: Trip/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TripId,DriverId,CityId,EmpId,DateStart,DateEnd,MessageContents,TripInfo,DriverBuddy")] Trip trip)
        {
            if (id != trip.TripId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(trip);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(trip.TripId))
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
            ViewData["CityId"] = new SelectList(_db.Cities, "CityId", "CityId", trip.CityId);
            ViewData["DriverId"] = new SelectList(_db.Drivers, "DriverId", "DriverId", trip.DriverId);
            return View(trip);
        }

        // GET: Trip/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _db.Trips
                .Include(t => t.Cities)
                .Include(t => t.Drivers)
                .FirstOrDefaultAsync(m => m.TripId == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trip = await _db.Trips.FindAsync(id);
            _db.Trips.Remove(trip);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripExists(int id)
        {
            return _db.Trips.Any(e => e.TripId == id);
        }*/
    }
}

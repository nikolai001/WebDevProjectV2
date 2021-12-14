using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AAO_App.Data;
using AAO_App.Models;
using Microsoft.AspNetCore.Http;


namespace AAO_App.Controllers
{
    public class AvailabilitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AvailabilitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AvailabilitiesTest
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Availabilities.Include(a => a.Drivers).Where(m => m.DriverId == int.Parse(this.HttpContext.Session.GetString("DriverId")));


             return View(await applicationDbContext.ToListAsync());
        }

        //GET: AvailabilitiesTest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availability = await _context.Availabilities
                .Include(a => a.Drivers)
                .FirstOrDefaultAsync(m => m.AvailabilityId == id);
            if (availability == null)
            {
                return NotFound();
            }

            return View(availability);
        }

        // GET: AvailabilitiesTest/Create
        public IActionResult Create()
        {
            //ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId");
            return View();
        }

        // POST: AvailabilitiesTest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AvailabilityId,Start,End,AvailabilityType")] Availability availability)
        {
            if (ModelState.IsValid)
            {
                availability.DriverId = int.Parse(this.HttpContext.Session.GetString("DriverId"));
                _context.Add(availability);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId", availability.DriverId);
            return View(availability);
        }

        // GET: AvailabilitiesTest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var availability = await _context.Availabilities.FindAsync(id);
            if (availability == null)
            {
                return NotFound();
            }
            //ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId", availability.DriverId);
            return View(availability);
        }

        // POST: AvailabilitiesTest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AvailabilityId,Start,End,AvailabilityType")] Availability availability)
        {
        

            if (ModelState.IsValid)
            {
                try
                {
                    availability.AvailabilityId = id;
                    availability.DriverId = int.Parse(this.HttpContext.Session.GetString("DriverId"));
                    _context.Update(availability);
                    await _context.SaveChangesAsync();
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
            //ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId", availability.DriverId);
            return View(availability);
        }

        // GET: AvailabilitiesTest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availability = await _context.Availabilities
                .Include(a => a.Drivers)
                .FirstOrDefaultAsync(m => m.AvailabilityId == id);
            if (availability == null)
            {
                return NotFound();
            }

            return View(availability);
        }

        // POST: AvailabilitiesTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var availability = await _context.Availabilities.FindAsync(id);
            _context.Availabilities.Remove(availability);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvailabilityExists(int id)
        {
            return _context.Availabilities.Any(e => e.AvailabilityId == id);
        }
    }
}

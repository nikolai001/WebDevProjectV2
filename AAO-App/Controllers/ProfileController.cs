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

namespace AAO_App
{
    public class ProfileController : Controller
    {

        //dependency Injection
        private readonly ApplicationDbContext _db;

        public ProfileController(ApplicationDbContext db)
        {
            _db = db;
        }
        //GET: Driver
        // GET: DriverTest
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _db.Drivers.Include(d => d.Cities);
            return View(await applicationDbContext.ToListAsync());
        }

        ////GET: DriverTest/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var driver = await _db.Drivers
        //        .Include(d => d.Cities)
        //        .FirstOrDefaultAsync(m => m.DriverId == id);
        //    if (driver == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(driver);
        //}

        //GET: DriverTest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _db.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_db.Cities, "CityId", "CityId", driver.CityId);
            return View(driver);
        }

        // POST: DriverTest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DriverId,CityId,Firstname,Lastname,Address,Phone,Location,Birthday,Password,IsValidated,ProfileImage")] Driver driver)
        {
            if (id != driver.DriverId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(driver);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverExists(driver.DriverId))
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
            ViewData["CityId"] = new SelectList(_db.Cities, "CityId", "CityId", driver.CityId);
            return View(driver);
        }

        // GET: DriverTest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var driver = await _db.Drivers
                .Include(d => d.Cities)
                .FirstOrDefaultAsync(m => m.DriverId == id);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        // POST: DriverTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var driver = await _db.Drivers.FindAsync(id);
            _db.Drivers.Remove(driver);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverExists(int id)
        {
            return _db.Drivers.Any(e => e.DriverId == id);
        }


    }
}

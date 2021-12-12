using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AAO_App.Data;
using AAO_App.Models;
//using BC = BCrypt.Net.BCrypt;

namespace AAO_App.Controllers
{
    public class NewUserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DriverTest/Create
        public IActionResult Index()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId");
            ViewData["CityName"] = new SelectList(_context.Cities, "CityName", "CityName");
            return View();
        }

        // POST: DriverTest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DriverId,CityId,Firstname,Lastname,Address,Phone,Location,Birthday,Password,IsValidated,ProfileImage")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                //driver.Password = BC.HashPassword(driver.Password); Some day my sweet prince some day
                _context.Add(driver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", driver.CityId);
            ViewData["CityName"] = new SelectList(_context.Cities, nameof(City.CityId), nameof(City.CityName), driver.CityId);
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
                    _context.Update(driver);
                    await _context.SaveChangesAsync();
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
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", driver.CityId);
            return View(driver);
        }

        // GET: DriverTest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Drivers
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
            var driver = await _context.Drivers.FindAsync(id);
            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverExists(int id)
        {
            return _context.Drivers.Any(e => e.DriverId == id);
        }
    }
}

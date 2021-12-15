using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AAO_App.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AAO_App.Controllers
{
    public class NotificationController : Controller
    {

        private readonly ApplicationDbContext _db;

        public NotificationController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        // GET: Trip
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _db.Trips.Include(t => t.Cities.Countries).Include(t => t.Employees).Where(m => m.DriverId == int.Parse(HttpContext.Session.GetString("DriverId")));
            return View(await applicationDbContext.ToListAsync());
        }
    }
}




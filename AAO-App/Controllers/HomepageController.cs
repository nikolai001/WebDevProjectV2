using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AAO_App.Data;
using AAO_App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AAO_App.Controllers
{
    public class HomepageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomepageController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: /<controller>/
        public IActionResult Index(Trip model)
        {
            var TripModelData = (from t in _context.Trips
                                 orderby t.TripId ascending
                                 select new Trip
                                 {
                                     TripId = t.TripId,
                                     DateStart = t.DateStart,
                                     DateEnd = t.DateEnd,
                                     MessageContents = t.MessageContents,
                                     TripInfo = t.TripInfo,
                                     EmployeeId = t.EmployeeId,
                                     DriverBuddy = t.DriverBuddy,

                                 }).Take(2).ToList();
            return View(TripModelData);
        }

    }
}

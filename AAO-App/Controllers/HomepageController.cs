using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AAO_App.Data;
using AAO_App.Models;
using Microsoft.EntityFrameworkCore;
<<<<<<< Updated upstream
using Microsoft.AspNetCore.Mvc.Rendering;
=======
using Microsoft.AspNetCore.Http;
>>>>>>> Stashed changes
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AAO_App
{
    public class HomepageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomepageController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("Home")]
        public ActionResult Index(TripModelView model)
        {

            var TripHomeData = (from t in _context.Trips
                                 join e in _context.Employees
                                 on t.EmployeeId equals e.EmployeeId
                                 join de in _context.DepartmentHasEmployees
                                 on t.EmployeeId equals de.DepartmentHasEmployeesId
                                 join d in _context.Departments
                                 on de.DepartmentHasEmployeesId equals d.DepId
                                 join ci in _context.Cities
                                 on t.CityId equals ci.CityId
                                 join co in _context.Countries
                                 on ci.CountryId equals co.CountryId
                                 join dt in _context.DriverHasTrips
                                 on t.TripId equals dt.TripId
                                 join dr in _context.Drivers
                                 on dt.DriverId equals dr.DriverId
                    
                                select new TripModelView
                                 {
                                     TripId = t.TripId,
                                     DateStart = t.DateStart,
                                     DateEnd = t.DateEnd,
                                     MessageContents = t.MessageContents,
                                     TripInfo = t.TripInfo,
<<<<<<< Updated upstream
                                     EmployeeId = t.EmployeeId,
                                     DriverBuddy = t.DriverBuddy,

                                 }).Take(2).ToList();
            return View(TripModelData);
=======
                                     Firstname = e.Firstname,
                                     Lastname = e.Lastname,
                                     Email = e.Email,
                                     Phone = e.Phone,
                                     DepartmentName = d.DepartmentName,
                                     CityName = ci.CityName,
                                     CountryCode = co.CountryCode,
                                     DriverId = dr.DriverId

                                 });


            return View(TripHomeData);

>>>>>>> Stashed changes
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AAO_App.Data;
using AAO_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AAO_App.Controllers
{ 
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ContactController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        //public async Task<IActionResult> IndexAsync()
        //{
        //    var applicationDbContext = _db.Employees;
        //    return View(await applicationDbContext.ToListAsync());
        //}
        public ActionResult Index(TripModelView model)
        {

            var TripModelData = (from t in _db.Trips
                                 join e in _db.Employees
                                 on t.EmployeeId equals e.EmployeeId
                                 join de in _db.DepartmentHasEmployees
                                 on t.EmployeeId equals de.DepartmentHasEmployeesId
                                 join d in _db.Departments
                                 on de.DepartmentHasEmployeesId equals d.DepId
                                 join ci in _db.Cities
                                 on t.CityId equals ci.CityId
                                 join co in _db.Countries
                                 on ci.CountryId equals co.CountryId

                                 select new TripModelView
                                 {
                                     TripId = t.TripId,
                                     DateStart = t.DateStart,
                                     DateEnd = t.DateEnd,
                                     MessageContents = t.MessageContents,
                                     TripInfo = t.TripInfo,
                                     Firstname = e.Firstname,
                                     Lastname = e.Lastname,
                                     Email = e.Email,
                                     Phone = e.Phone,
                                     DepartmentName = d.DepartmentName,
                                     CityName = ci.CityName,
                                     CountryCode = co.CountryCode

                                 }).ToList();


            return View(TripModelData);

        }
        // GET: Calendar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _db.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
    }
}

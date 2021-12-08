using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AAO_App.Data;
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
        public async Task<IActionResult> IndexAsync()
        {
            var applicationDbContext = _db.Employees;
            return View(await applicationDbContext.ToListAsync());
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

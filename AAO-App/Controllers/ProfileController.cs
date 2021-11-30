using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AAO_App.Data;
using AAO_App.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AAO_App.Controllers
{
    public class ProfileController : Controller
    {

        //dependency Injection
        private readonly ApplicationDbContext _db;

        public ProfileController(ApplicationDbContext db)
        {
            _db = db;
        }

        
        // GET: /<controller>/
        public IActionResult Index()
        {
            /*var DriverID = Driver.Identity.GetDriverId();

            Profile.Firstname = Driver.FirstName;
            Profile.Address = Driver.Address;
            Profile.Location = Driver.Location;
            Profile.DriverLicensType = Driver.DriverLicensType;
            */

            return View();
        }

        
    }
}

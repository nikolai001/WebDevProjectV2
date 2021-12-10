using AAO_App.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;


namespace AAO_App.Controllers
{
    [Route("login")]

    public class LoginController : Controller
    {
        //dependency Injection
        private readonly ApplicationDbContext _db;

        public LoginController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("")]
        [Route("index")]
        [Route("~/")]
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [Route("index")]
        [HttpPost]
        public IActionResult Login(string phone, string password)
        {
            //var User = _db.Drivers.Select(d => d).Where(d => d.Phone == phone);
            //bool verified = BC.Verify(password, _db.Drivers.Select(d => d).Where(d => d.Password == d.Password)); Maybe some day
            if (phone != null && password != null && _db.Drivers.Select(d => d).Where(d => d.Phone == phone && d.Password == password).ToList().Count() > 0) // Klam måde at tjekke login på, bør omskrives.. eventually.. Kraftedeme en bootleg måde jeg fandt her
            {

                HttpContext.Session.SetString("phone", phone);
                return View("~/Views/Homepage/Index.cshtml");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }
        }
        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("phone");
            return RedirectToAction("Index");
        }
    }

}

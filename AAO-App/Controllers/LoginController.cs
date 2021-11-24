using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AAO_App.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public IActionResult Login(string username, string password)
        {
            if (username != null && password != null && username.Equals("acc1") && password.Equals("123"))
            {
                HttpContext.Session.SetString("username", username);
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
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }
    }
}
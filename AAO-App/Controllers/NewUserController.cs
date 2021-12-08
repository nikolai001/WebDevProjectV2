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

    public class NewUserController : Controller

    {

        //dependency Injection
        private readonly ApplicationDbContext _db;

        public NewUserController(ApplicationDbContext db)
        {
            _db = db;

        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // POST
        [HttpPost]
        public IActionResult Index(Driver obj)
        {
            Console.WriteLine(obj);
            _db.Drivers.Add(obj);
            _db.SaveChanges();
            return View();
        }
    }
}
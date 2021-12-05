using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AAO_App.Data;
using AAO_App.Models;

namespace AAO_App
{
    public class ProfileController : Controller
    {

        //dependency Injection
        private readonly ApplicationDbContext _db;

        public ProfileController(ApplicationDbContext db)
        {
            _db = db;
        }
        //GET: Driver
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _db.Drivers;
            return View(await applicationDbContext.ToListAsync());
        }

        
    }
}

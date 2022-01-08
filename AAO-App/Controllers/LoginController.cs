﻿using AAO_App.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;


namespace AAO_App
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
            //var driver = _db.Drivers.Select(d => d).Where(d => d.Phone == phone && d.Password == password).ToList();

            var account = _db.Drivers.SingleOrDefault(x => x.Phone == phone);

            if (account == null || !BC.Verify(password,account.Password))
            {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }
            else
            {
                // HttpContext.Session.SetString("Address", driver[0].Address);
                //HttpContext.Session.SetString("Birthday", driver[0].Birthday.ToString());
                // HttpContext.Session.SetString("CityId", driver[0].CityId.ToString());
                HttpContext.Session.SetString("DriverId", account.DriverId.ToString());
                HttpContext.Session.SetString("Firstname", account.Firstname);
                HttpContext.Session.SetString("Lastname", account.Lastname);
                HttpContext.Session.SetString("CityId", account.CityId.ToString());
                //HttpContext.Session.SetString("Location", driver[0].Location);
                //HttpContext.Session.SetString("Phone", driver[0].Phone);

                //return View("~/Views/Homepage/Index");
                return RedirectToAction("Index", "Home");
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

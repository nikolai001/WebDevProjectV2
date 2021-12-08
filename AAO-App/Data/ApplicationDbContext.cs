using AAO_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Availability> Availabilities { get; set; }

        public DbSet<LicensType> LicensTypes { get; set; }

        public DbSet<DriverLicensType> DriverLicensTypes { get; set; }

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<DepartmentHasEmployee> DepartmentHasEmployees { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<DriverHasTrip> DriverHasTrips { get; set; }


    }
}

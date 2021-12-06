using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_App.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }
        public int DriverId { get; set; }
        public Driver Drivers { get; set; }
        public int CityId { get; set; }
        public City Cities { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employees { get; set; }
       
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string MessageContents { get; set; }
        public string TripInfo { get; set; }
        public string DriverBuddy { get; set; }

    }
}

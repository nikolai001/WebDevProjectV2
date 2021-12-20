using System;
using System.Collections.Generic;

namespace AAO_App.Models
{
    public class TripModelView
    {

        //Fra Trips
        public int TripId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string MessageContents { get; set; }
        public string TripInfo { get; set; }

        //Fra Employees
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //Fra Departments
        public string DepartmentName { get; set; }

        //Fra City
        public string CityName { get; set; }

        //Fra Countrey 
        public string CountryCode { get; set; }

        //Fra Driver
        public int DriverId { get; set; }

        //Fra DriverHasTrip
        public int RequestStatus { get; set; }

    }
}

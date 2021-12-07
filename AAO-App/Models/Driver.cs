using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_App.Models
{
    public class Driver
    {

        [Key]
        public int DriverId { get; set; }
        public int LoginId { get; set; }
        public Login UserLogin { get; set; }
        public int DriverLicensType { get; set; }
        public DriverLicensType DriverLicensTypes { get; set; }
        public int CityId { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public DateTime Birthday { get; set; }


    }
}

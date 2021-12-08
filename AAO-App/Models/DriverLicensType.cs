using System;
using System.ComponentModel.DataAnnotations;

namespace AAO_App.Models
{
    public class DriverLicensType
    {
        [Key]
        public int DriverLicensTypeId { get; set; }

        public int DriverId { get; set; }
        public Driver Drivers { get; set; }

        public int LicensTypeId { get; set; }
        public LicensType LicensTypes { get; set; }

    }
}

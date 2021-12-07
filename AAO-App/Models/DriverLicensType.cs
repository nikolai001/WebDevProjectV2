using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_App.Models
{
    public class DriverLicensType
    {
        [Key]
        public int DriverLicensTypeId { get; set; }
        
        //foreign keys
        public int DriverId { get; set; }
        public Driver Drivers { get; set; }

        public int LicensTypeId { get; set; }
        public LicensType LicensTypes { get; set; }

    }
}

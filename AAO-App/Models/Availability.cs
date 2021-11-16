using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_App.Models
{
    public class Availability
    {

        [Key]
        public int AvailabilityId { get; set; }

        //Foreign key
        public int DriverId { get; set; }
        public Driver Drivers { get; set; }
        public int AvailabilityTypeId { get; set; }
        public AvailabilityType AvailabilityTypes { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}

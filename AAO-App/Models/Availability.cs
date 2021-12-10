using System;
using System.ComponentModel.DataAnnotations;

namespace AAO_App.Models
{
    public class Availability
    {
        [Key]
        public int AvailabilityId { get; set; }

        //Foreign key
        public int DriverId { get; set; }
        public Driver Drivers { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime End { get; set; }
        public int AvailabilityType { get; set; }
    }
}

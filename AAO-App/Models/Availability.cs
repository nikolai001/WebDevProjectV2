using System;
using System.Collections.Generic;
using System.ComponentModel;
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
       
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Start Dato:")]
        public DateTime Start { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Slut Dato:")]
        public DateTime End { get; set; }
        public int AvailabilityType { get; set; }
    }

}

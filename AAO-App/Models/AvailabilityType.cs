using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_App.Models
{
    public class AvailabilityType
    {

            [Key]
            public int AvailabilityTypeId { get; set; }
            public string Type { get; set; }
        
    }
}

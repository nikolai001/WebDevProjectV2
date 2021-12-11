using System;
using System.ComponentModel.DataAnnotations;

namespace AAO_App.Models
{
    public class DriverHasTrip
    {
        [Key]
        public int DriverHasTripId { get; set; }
        public int DriverId { get; set; }
        public Driver Drivers { get; set; }
        public int? TripId { get; set; }
        public Trip Trips { get; set; }
        public int RequestStatus { get; set; }
    }
}
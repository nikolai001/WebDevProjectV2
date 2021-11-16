using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_App.Models
{
    public class Department
    {
        [Key]
        public int DepId { get; set; }
        public int CityId { get; set; }
        public City Cities { get; set; }
        public string CityName { get; set; }
        public string Address { get; set; }
    }
}

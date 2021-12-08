using System;
using System.ComponentModel.DataAnnotations;

namespace AAO_App.Models
{
    public class Department
    {
        [Key]
        public int DepId { get; set; }
        public int CityId { get; set; }
        public City Cities { get; set; }
        public string DepartmentName { get; set; }
        public string Address { get; set; }
    }
}

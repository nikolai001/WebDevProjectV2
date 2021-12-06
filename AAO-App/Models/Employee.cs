using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_App.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string  Email { get; set; }
        public string Phone { get; set; }
    }
}

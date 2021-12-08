using System;
using System.ComponentModel.DataAnnotations;

namespace AAO_App.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}

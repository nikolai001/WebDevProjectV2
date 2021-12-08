using System;
using System.ComponentModel.DataAnnotations;

namespace AAO_App.Models
{
    public class DepartmentHasEmployee
    {
        [Key]
        public int DepartmentHasEmployeesId { get; set; }
        public int DepartmentId { get; set; }
        public Department Departments { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employees { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind_Management_System.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string? Address { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public Employee? Manager { get; set; }
        public ICollection<Employee>? Subordinates { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}

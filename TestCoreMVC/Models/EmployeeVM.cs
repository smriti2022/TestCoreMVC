using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCoreMVC.Models
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmailId { get; set; }
        public int ContactNumber { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public string Gender { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

    }
}

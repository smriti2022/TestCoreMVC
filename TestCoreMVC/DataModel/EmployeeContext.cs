using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCoreMVC.Models;

namespace TestCoreMVC.DataModel
{
    public class EmployeeContext : DbContext

    {

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set;}

    }
}

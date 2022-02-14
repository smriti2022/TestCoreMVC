using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCoreMVC.DataModel;
using TestCoreMVC.Models;

namespace TestCoreMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _employeeContext;
        public EmployeeController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<EmployeeVM> employeeList = new List<EmployeeVM>();


            employeeList = await (from c in _employeeContext.Employees
                                  join ct in _employeeContext.Departments on c.DepartmentId equals ct.Id into g
                                  from ct in g.DefaultIfEmpty()
                                  select new EmployeeVM
                                  {
                                      Id = c.Id,
                                      EmployeeName = c.EmployeeName,
                                      EmailId = c.EmailId,
                                      ContactNumber = c.ContactNumber,
                                      Address = c.Address,
                                      Salary = c.Salary,
                                      Gender = c.Gender,
                                      DepartmentId = c.DepartmentId,
                                      DepartmentName = ct.DepartmentName
                                  }).ToListAsync();

            return View(employeeList);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            var Department = _employeeContext.Departments.ToList();
            ViewBag.DepartmentId = new SelectList(Department, "Id", "DepartmentName");
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            this._employeeContext.Employees.Add(employee);
            this._employeeContext.SaveChanges();
            return RedirectToAction("Index");
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult Update(int Id)
        {
            var Department = _employeeContext.Departments.ToList();
            ViewBag.DepartmentId = new SelectList(Department, "Id", "DepartmentName");
            // var result = _employeeContext.Employees.Where(a => a.Id == Id).FirstOrDefault();
            return View(_employeeContext.Employees.Where(a => a.Id == Id).FirstOrDefault());
        }

        /// <summary>
        /// This method use to update employee data into database.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update_Post(Employee employee)
        {
            _employeeContext.Employees.Update(employee);
            _employeeContext.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// This method use to delete employee data from the database.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var teacher = _employeeContext.Employees.Where(a => a.Id == Id).FirstOrDefault();
            _employeeContext.Employees.Remove(teacher);
            _employeeContext.SaveChanges();
            return RedirectToAction("Index");
        }







    }
}

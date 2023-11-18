using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineCommercialAutomation.Models.Classes;

namespace MVCOnlineCommercialAutomation.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context context = new Context();
        public ActionResult Index()
        {
            var departments = context.Departments.Where(x => x.Status == true).ToList();
            return View(departments);
        }
        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDepartment(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteDepartment(int id)
        {
            var department = context.Departments.Find(id);
            department.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetDepartment(int id)
        {
            var department = context.Departments.Find(id);
            return View("GetDepartment", department);
        }

        public ActionResult UpdateDepartment(Department department)
        {
            var dep = context.Departments.Find(department.DepartmentId);
            dep.DepartmentName = department.DepartmentName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DetailDepartment(int id)
        {
            var department = context.Employees
                .Where(x => x.DepartmentId == id).ToList();
            var dep = context.Departments
                .Where(x => x.DepartmentId == id).Select(y => y.DepartmentName)
                .FirstOrDefault();
            ViewBag.dpt = dep;
            return View(department);

        }

        public ActionResult DepartmentEmployeeSale(int id)
        {
            var values = context.SaleTransactions.Where(x=>x.EmployeeId==id).ToList();
            var employee = context.Employees
                .Where(x => x.EmployeeId == id)
                .Select(y => y.EmployeeName + " " + y.EmployeeSurname)
                .FirstOrDefault();
            ViewBag.dpt = employee;
            return View(values);
        }

    }
}
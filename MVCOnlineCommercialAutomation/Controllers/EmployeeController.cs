using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineCommercialAutomation.Models.Classes;

namespace MVCOnlineCommercialAutomation.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        Context context = new Context();
        public ActionResult Index()
        {
            var employees = context.Employees.ToList();
            //.Where(x => x.Status == true)
            return View(employees);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {

            List<SelectListItem> value = (from x in context.Departments.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmentName, //label
                                              Value = x.DepartmentId.ToString()//value
                                          }).ToList();
            ViewBag.val1 = value;
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Images/" + fileName;
                Request.Files[0].SaveAs(Server.MapPath(path));
                employee.EmployeeImage = "/Images/" + fileName ;
            }
            context.Employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEmployee(int id)
        {
            var employee = context.Employees.Find(id);
            //employee.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetEmployee(int id)
        {
            List<SelectListItem> value = (from x in context.Departments.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmentName, //label
                                              Value = x.DepartmentId.ToString()//value
                                          }).ToList();
            ViewBag.val1 = value;
            var employee = context.Employees.Find(id);
            return View("GetEmployee", employee);
        }

        public ActionResult UpdateEmployee(Employee employee)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Images/" + fileName;
                Request.Files[0].SaveAs(Server.MapPath(path));
                employee.EmployeeImage = "/Images/" + fileName;
            }
            var e = context.Employees.Find(employee.EmployeeId);
            e.EmployeeName = employee.EmployeeName;
            e.EmployeeSurname = employee.EmployeeSurname;
            e.EmployeeImage = employee.EmployeeImage;
            e.DepartmentId = employee.DepartmentId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult DetailEmployee(int id)
        //{
        //    var employee = context.Employees
        //        .Where(x => x.EmployeeId == id).ToList();
        //    var dep = context.Employees
        //        .Where(x => x.EmployeeId == id).Select(y => y.EmployeeName)
        //        .FirstOrDefault();
        //    ViewBag.dpt = dep;
        //    return View(employee);
        //    return View();

        //}
        public ActionResult EmployeeList(Employee employee)
        {
            var query = context.Employees.ToList();
            //var e = context.Employees.Find(employee.EmployeeId);
            //e.EmployeeName = employee.EmployeeName;
            //e.EmployeeSurname = employee.EmployeeSurname;
            //e.EmployeeImage = employee.EmployeeImage;
            //e.DepartmentId = employee.DepartmentId;
            //context.SaveChanges();
            //return RedirectToAction("Index");
            return View(query);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineCommercialAutomation.Models.Classes;

namespace MVCOnlineCommercialAutomation.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        Context context = new Context();
        public ActionResult Index()
        {
            var customers = context.Customers.Where(x => x.Status == true).ToList();
            return View(customers);
        }

        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            customer.Status = true;
            context.Customers.Add(customer);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCustomer(int id)
        {
            var customer = context.Customers.Find(id);
            customer.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCustomer(int id)
        {
            var customer = context.Customers.Find(id);
            return View("GetCustomer", customer);
        }

        public ActionResult UpdateCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return View("GetCustomer");
            }
            var c = context.Customers.Find(customer.CustomerId);
            c.CustomerName = customer.CustomerName;
            c.CustomerSurname= customer.CustomerSurname;
            c.CustomerCity = customer.CustomerCity;
            c.CustomerEmail= customer.CustomerEmail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult DetailCustomer(int id)
        //{
        //    var customer = context.Employees
        //        .Where(x => x.CustomerId == id).ToList();
        //    var dep = context.Customers
        //        .Where(x => x.CustomerId == id).Select(y => y.CustomerName)
        //        .FirstOrDefault();
        //    ViewBag.dpt = dep;
        //    return View(customer);
        //    return View();

        //}

        public ActionResult CustomerSale(int id)
        {
            var values = context.SaleTransactions.Where(x => x.CustomerId == id).ToList();
            var customer = context.Customers
                .Where(x => x.CustomerId == id)
                .Select(y => y.CustomerName + " " + y.CustomerSurname)
                .FirstOrDefault();
            ViewBag.cus = customer;
            return View(values);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineCommercialAutomation.Models.Classes;

namespace MVCOnlineCommercialAutomation.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDo
        Context context = new Context();
        public ActionResult Index()
        {
            var val1 = context.Customers.Count().ToString();
            var val2 = context.Products.Count().ToString();
            var val3 = context.Categories.Count().ToString();
            var val4 = (from x in context.Customers select x.CustomerCity).Distinct().Count().ToString();
            ViewBag.v1 = val1;
            ViewBag.v2 = val2;
            ViewBag.v3 = val3;
            ViewBag.v4 = val4;

            var ToDo = context.ToDoClasses.ToList();
            return View(ToDo);
        }
    }
}
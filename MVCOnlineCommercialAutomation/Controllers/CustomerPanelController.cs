using MVCOnlineCommercialAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineCommercialAutomation.Controllers
{
    public class CustomerPanelController : Controller
    {
        Context context = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var email = (string)Session["CustomerEmail"];
            var values = context.Customers.FirstOrDefault(x => x.CustomerEmail == email);
            return View(values);
        }
        [HttpPost]
        public ActionResult Index2()
        {
            var email = (string)Session["CustomerEmail"];
            var values = context.Customers.FirstOrDefault(x => x.CustomerEmail == email);
            return View(values);
        }

        public ActionResult Orders()
        {
            var email = (string)Session["CustomerEmail"];
            var id = context.Customers.Where(x => x.CustomerEmail == email.ToString()).Select(y => y.CustomerId).FirstOrDefault();
            var orders = context.SaleTransactions.Where(x => x.CustomerId == id).ToList();
            return View(orders);
        }
    }
}
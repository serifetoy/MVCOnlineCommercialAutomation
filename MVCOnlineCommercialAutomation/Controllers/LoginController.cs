using MVCOnlineCommercialAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCOnlineCommercialAutomation.Controllers
{
    [AllowAnonymous]//global axasdaki veriler dışında bu sayfayı hariç tut
    public class LoginController : Controller
    {
        // GET: Login
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial1()//Customer Register Form
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Partial1(Customer customer)//
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CustomerLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerLogin1(Customer customer)
        {
            var inf = context.Customers.FirstOrDefault(x => x.CustomerEmail == customer.CustomerEmail && x.CustomerPassword == customer.CustomerPassword);

            if (inf != null)
            {
                FormsAuthentication.SetAuthCookie(inf.CustomerEmail, false);
                Session["CustomerEmail"] = inf.CustomerEmail.ToString();
                return RedirectToAction("Index", "CustomerPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

        [HttpGet]
        public ActionResult AdminLogin()
        {

            return View();
        }

        public ActionResult AdminLogin(Admin admin)
        {

            var info = context.Admins.FirstOrDefault(x => x.AdminName == admin.AdminName && x.Password == admin.Password);
            if (info != null)
            {
                FormsAuthentication.SetAuthCookie(info.AdminName, false);
                Session["AdminName"] = info.AdminName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                //ModelState.AddModelError("a", "Kullanıcı adı veya şifre hatalı."); olmadı burası
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
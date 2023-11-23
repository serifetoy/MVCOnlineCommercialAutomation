using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineCommercialAutomation.Models.Classes;

namespace MVCOnlineCommercialAutomation.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        Context context = new Context();
        public ActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }
    }
}
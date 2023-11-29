using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineCommercialAutomation.Models.Classes;

namespace MVCOnlineCommercialAutomation.Controllers
{
    public class ProductDetailsController : Controller
    {
        // GET: ProductDetails
        Context context = new Context();
        public ActionResult Index()
        {
            //var products = context.Products.Where(x => x.ProductId == 1).ToList();
            ProductIntroduction products = new ProductIntroduction();
            products.ProductId = context.Products.Where(x => x.ProductId == 1).ToList();
            products.DetailForProductId = context.DetailForProducts.Where(x => x.DetailForProductId == 1).ToList();
            return View(products);
        }
    }
}
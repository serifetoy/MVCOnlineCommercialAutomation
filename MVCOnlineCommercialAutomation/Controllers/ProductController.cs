using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineCommercialAutomation.Models.Classes;
using Newtonsoft.Json.Linq;
using PagedList;
using static System.Net.Mime.MediaTypeNames;

namespace MVCOnlineCommercialAutomation.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context context = new Context();
        public ActionResult Index(int page = 1, string parameter = null )
        {
            var products = from x in context.Products select x;
            if (!string.IsNullOrEmpty(parameter))
            {
                products = products.Where(y => y.ProductName.Contains(parameter));

            }
            return View(products.ToList().ToPagedList(page, 5));
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> value = (from x in context.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName, //label
                                              Value = x.CategoryId.ToString()//value
                                          }).ToList();
            ViewBag.val1 = value;
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int id)
        {
            var product = context.Products.Find(id);
            product.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetProduct(int id)
        {
            List<SelectListItem> value = (from x in context.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName, //label
                                              Value = x.CategoryId.ToString()//value
                                          }).ToList();
            ViewBag.val1 = value;

            var product = context.Products.Find(id);
            return View("Getproduct", product);
        }
        public ActionResult UpdateProduct(Product product)
        {
            var p = context.Products.Find(product.ProductId);
            p.ProductName = product.ProductName;
            p.PurchasePrice = product.PurchasePrice;
            p.Status = product.Status;
            p.Brand = product.Brand;
            p.ProductImage = product.ProductImage;
            p.SellingePrice = product.SellingePrice;
            p.CategoryId = product.CategoryId;
            p.Stock = product.Stock;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductList()
        {
            var products = context.Products.ToList();
            return View(products);
        }
    }
}
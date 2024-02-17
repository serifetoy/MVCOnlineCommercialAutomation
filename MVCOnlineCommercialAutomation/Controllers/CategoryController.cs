using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineCommercialAutomation.Models.Classes;
using PagedList;
using PagedList.Mvc;

namespace MVCOnlineCommercialAutomation.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context context = new Context();
        public ActionResult Index(int page = 1)//start page one 
        {
            var categories = context.Categories.ToList().ToPagedList(page, 5);
            return View(categories);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            var category = context.Categories.Find(id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCategory(int id)
        {
            var category = context.Categories.Find(id);
            return View("GetCategory", category);
        }

        public ActionResult UpdateCategory(Category category)
        {
            var cat = context.Categories.Find(category.CategoryId);
            cat.CategoryName = category.CategoryName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CascadingTest()
        {
            CascadingClass cs = new CascadingClass();
            cs.Categories = new SelectList(context.Categories, "CategoryId", "CategoryName");
            cs.Products = new SelectList(context.Products, "ProductId", "ProductName");
            return View(cs);
        }
        public JsonResult GetProduct(int p)
        {
            var productList = (from x in context.Products
                               join y in context.Categories
                               on x.Category.CategoryId equals y.CategoryId
                               where x.Category.CategoryId == p
                               select new
                               {
                                   Text = x.ProductName,
                                   Value = x.ProductId.ToString(),
                               }).ToList();

            return Json(productList, JsonRequestBehavior.AllowGet);
        }
    }
}
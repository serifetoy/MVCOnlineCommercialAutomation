using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MVCOnlineCommercialAutomation.Models.Classes;
using Context = MVCOnlineCommercialAutomation.Models.Classes.Context;
using System.Collections;

namespace MVCOnlineCommercialAutomation.Controllers
{
    public class GraphicController : Controller
    {
        // GET: Graphic
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var drawGraph = new Chart(600, 600);
            drawGraph.AddTitle("Category - Number of Product Stocks").AddLegend("Stock").AddSeries("Values",
            xValue: new[] { "Furniture", "Refrigerator", "Computer" },
            yValues: new[] { 85, 66, 98 }).Write();
            return File(drawGraph.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var results = context.Products.ToList();
            results.ToList().ForEach(x => xvalue.Add(x.ProductName));
            results.ToList().ForEach(y => yvalue.Add(y.Stock));
            var graph = new Chart(width: 800, height: 800)
            .AddTitle("stocks")
            .AddSeries(chartType: "Pie", name: "Stock", xValue: xvalue, yValues: yvalue);
            return File(graph.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult Index5()
        {
            return View();
        }//db View pie
        public ActionResult Index6()
        {
            return View();
        }//db View line
        public ActionResult Index7()
        {
            return View();
        }//db View column
        public ActionResult VisualizeProductResult()
        {
            return Json(ProductList(), JsonRequestBehavior.AllowGet);
        }
        public List<ProductStock> ProductList()
        {
            List<ProductStock> products = new List<ProductStock>();
            products.Add(new ProductStock()
            {
                ProductName = "Computer",
                Stock = 120
            });
            products.Add(new ProductStock()
            {
                ProductName = "Refrigerator",
                Stock = 150
            });
            products.Add(new ProductStock()
            {
                ProductName = "Furniture",
                Stock = 180
            });
            products.Add(new ProductStock()
            {
                ProductName = "Smaal Appliances",
                Stock = 70
            });
            products.Add(new ProductStock()
            {
                ProductName = "Phone",
                Stock = 90
            });

            return products;
        }
        public ActionResult VisualizeProductResultDb()
        {
            return Json(ProductListDb(), JsonRequestBehavior.AllowGet);
        }
        public List<ProductStockDb> ProductListDb()
        {
            List<ProductStockDb> products = new List<ProductStockDb>();
            using (var context = new Context())
            {
                products = context.Products.Select(x => new ProductStockDb
                {
                    ProductNameDb = x.ProductName,
                    StockDb = x.Stock

                }).ToList();
            }
            return products;
        }
    }
}
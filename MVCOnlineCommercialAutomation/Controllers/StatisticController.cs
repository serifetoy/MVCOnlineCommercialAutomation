using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineCommercialAutomation.Models.Classes;

namespace MVCOnlineCommercialAutomation.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistics
        Context context = new Context();
        public ActionResult Index()
        {
            var value1 = context.Customers.Count().ToString();
            ViewBag.v1 = value1;

            var value2 = context.Products.Count().ToString();
            ViewBag.v2 = value2;

            var value3 = context.Employees.Count().ToString();
            ViewBag.v3 = value3;

            var value4 = context.Categories.Count().ToString();
            ViewBag.v4 = value4;

            var value5 = context.Products.Sum(x => x.Stock).ToString();
            ViewBag.v5 = value5;

            var value6 = (from x in context.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.v6 = value6;

            var value7 = context.Products.Count(x => x.Stock <= 20).ToString();//kritik seviye stok sayısı 20nin altında olanlar
            ViewBag.v7 = value7;

            var value8 = (from x in context.Products orderby x.SellingePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.v8 = value8;

            var value9 = (from x in context.Products orderby x.SellingePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.v9 = value9;

            var value10 = context.Products.GroupBy(x => x.Brand)
                .OrderByDescending(z => z.Count())
                .Select(x => x.Key)
                .FirstOrDefault();
            ViewBag.v10 = value10;

            var value11 = context.Products.Count(x => x.ProductName == "Refrigerator").ToString();
            ViewBag.v11 = value11;

            var value12 = context.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.v12 = value12;


            var value13 = context.Products
                .Where(p => p.ProductId == context.SaleTransactions.GroupBy(x => x.ProductId)
                .OrderByDescending(z => z.Count())
                .Select(x => x.Key)
                .FirstOrDefault())
                .Select(k=>k.ProductName).FirstOrDefault();
            ViewBag.v13 = value13;


            //var value14 = context.SaleTransactions.Sum(x => x.TotalAmount).ToString();
            //ViewBag.v14 = value14;//önceki kod, style için alttakini yazdım.

            int value14 = (int)(context.SaleTransactions.Sum(x => x.TotalAmount));
            ViewBag.v14 = value14;

            DateTime today = DateTime.Today;
            var value15 = context.SaleTransactions.Count(x => x.SaleTransactionDate == today).ToString();
            ViewBag.v15 = value15;

            //var value16 = context.SaleTransactions.Where(x => x.SaleTransactionDate == today)
            //    .Sum(y=>y.TotalAmount)
            //    .ToString();
            //ViewBag.v16 = value16;


            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineCommercialAutomation.Models.Classes;

namespace MVCOnlineCommercialAutomation.Controllers
{
    public class SaleTransactionController : Controller
    {
        // GET: SaleTransaction
        Context context = new Context();
        public ActionResult Index()
        {
            var sales = context.SaleTransactions.ToList();
            return View(sales);
        }
        [HttpGet]
        public ActionResult AddSaleTransaction()
        {
            List<SelectListItem> saleproduct = (from x in context.Products.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ProductName,
                                             Value = x.ProductId.ToString(),
                                         }).ToList();
            

            List<SelectListItem> salecustomer = (from x in context.Customers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CustomerName + " " + x.CustomerSurname,
                                             Value = x.CustomerId.ToString(),
                                         }).ToList();
            

            List<SelectListItem> saleemployee = (from x in context.Employees.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.EmployeeName + " " + x.EmployeeSurname,
                                                     Value = x.EmployeeId.ToString(),
                                                 }).ToList();
            ViewBag.val1 = saleproduct;
            ViewBag.val2 = salecustomer;
            ViewBag.val3 = saleemployee;
            return View();
        }

        [HttpPost]
        public ActionResult AddSaleTransaction(SaleTransaction saleTransaction)
        {
            saleTransaction.SaleTransactionDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SaleTransactions.Add(saleTransaction);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetSaleTransaction(int id)
        {
            List<SelectListItem> saleproduct = (from x in context.Products.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.ProductName,
                                                    Value = x.ProductId.ToString(),
                                                }).ToList();


            List<SelectListItem> salecustomer = (from x in context.Customers.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CustomerName + " " + x.CustomerSurname,
                                                     Value = x.CustomerId.ToString(),
                                                 }).ToList();


            List<SelectListItem> saleemployee = (from x in context.Employees.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.EmployeeName + " " + x.EmployeeSurname,
                                                     Value = x.EmployeeId.ToString(),
                                                 }).ToList();
            ViewBag.val1 = saleproduct;
            ViewBag.val2 = salecustomer;
            ViewBag.val3 = saleemployee;
            var saleTransaction = context.SaleTransactions.Find(id);
            return View("GetSaleTransaction", saleTransaction);
        }

        public ActionResult UpdateSaleTransaction(SaleTransaction saleTransaction)
        {
            var sale = context.SaleTransactions.Find(saleTransaction.SaleTransactionId);
            sale.CustomerId = saleTransaction.CustomerId;
            sale.Quantity = saleTransaction.Quantity;
            sale.ProductId= saleTransaction.ProductId;
            sale.EmployeeId= saleTransaction.EmployeeId;
            sale.TotalAmount = saleTransaction.TotalAmount;
            sale.Price= saleTransaction.Price;
            sale.SaleTransactionDate= saleTransaction.SaleTransactionDate;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DetailSaleTransaction(int id)
        {
            var values = context.SaleTransactions.Where(x => x.SaleTransactionId == id).ToList();
            //var employee = context.Employees
            //    .Where(x => x.EmployeeId == id)
            //    .Select(y => y.EmployeeName + " " + y.EmployeeSurname)
            //    .FirstOrDefault();
            //ViewBag.dpt = employee;
            return View(values);
        }
    }
}
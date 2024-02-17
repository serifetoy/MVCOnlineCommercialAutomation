using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineCommercialAutomation.Models.Classes;

namespace MVCOnlineCommercialAutomation.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context context = new Context();
        public ActionResult Index()
        {
            var invoices = context.Invoices
                //.Where(x => x.Status == true)
                .ToList();
            return View(invoices);
        }

        [HttpGet]
        public ActionResult AddInvoice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddInvoice(Invoice invoice)
        {
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetInvoice(int id)
        {
            var invoice = context.Invoices.Find(id);
            return View("GetInvoice", invoice);
        }

        public ActionResult UpdateInvoice(Invoice invoice)
        {
            var inv = context.Invoices.Find(invoice.InvoiceId);
            inv.InvoiceSerialNo =invoice.InvoiceSerialNo;
            inv.InvoiceSequenceNo = invoice.InvoiceSequenceNo;
            inv.InvoiceDate= invoice.InvoiceDate;
            inv.InvoiceTime= invoice.InvoiceTime;
            inv.TaxAdministration = invoice.TaxAdministration;
            inv.Deliverer= invoice.Deliverer;
            inv.Receiver= invoice.Receiver;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DetailInvoice(int id)
        {
            var invoice = context.InvoiceItems
                .Where(x => x.InvoiceId == id).ToList();
            //var dep = context.Invoices
            //    .Where(x => x.InvoiceId == id).Select(y => y.InvoiceName)
            //    .FirstOrDefault();
            //ViewBag.dpt = dep;
            return View(invoice);

        }

        [HttpGet]
        public ActionResult AddInvoiceItem()
        {
            return View();
        }
        public ActionResult AddInvoiceItem(InvoiceItem invoiceitem)
        {
            context.InvoiceItems.Add(invoiceitem);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DynamicInvoice()
        {
            DynamicInv dynamic = new DynamicInv();
            dynamic.InvoiceValue = context.Invoices.ToList();
            dynamic.InvoiceItemValue = context.InvoiceItems.ToList();
            return View(dynamic);
        }
    }
}
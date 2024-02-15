using MVCOnlineCommercialAutomation.Models.Classes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace MVCOnlineCommercialAutomation.Controllers
{
    public class CustomerPanelController : Controller
    {
        Context context = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var email = (string)Session["CustomerEmail"];
            var values = context.Messages.Where(x => x.Receiver == email).ToList();
            ViewBag.Message = email;
            var emailId = context.Customers.Where(x => x.CustomerEmail == email).Select(y => y.CustomerId).FirstOrDefault();
            ViewBag.EmailId = emailId;
            var totalSale = context.SaleTransactions.Where(x => x.CustomerId == emailId).Count();
            ViewBag.TotalSale = totalSale;
            var totalAmount = context.SaleTransactions.Where(x => x.CustomerId == emailId).Sum(y => y.TotalAmount);
            ViewBag.TotalAmount = totalAmount;
            var totalProducts = context.SaleTransactions.Where(x => x.CustomerId == emailId).Sum(y => y.Quantity);
            ViewBag.TotalProducts = totalProducts;
            var nameSurname = context.Customers.Where(x => x.CustomerEmail == email).Select(y => y.CustomerName + " " + y.CustomerSurname).FirstOrDefault();
            ViewBag.Name = nameSurname;
            //var message = context.Messages.Where(x => x.Receiver == email).ToList();
            //ViewBag.Message = message;
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

        public ActionResult IncomingMessages()
        {
            var email = (string)Session["CustomerEmail"];
            var messages = context.Messages.Where(x => x.Receiver == email).OrderByDescending(x => x.MessageId).ToList();
            var incomingmessage = context.Messages.Count(x => x.Receiver == email).ToString();
            var outgoingmessage = context.Messages.Count(x => x.Sender == email).ToString();
            ViewBag.outgoingmessage = outgoingmessage;
            ViewBag.incomingmessage = incomingmessage;
            return View(messages);
        }
        public ActionResult OutgoingMessages()
        {
            var email = (string)Session["CustomerEmail"];
            var messages = context.Messages.Where(x => x.Sender == email).OrderByDescending(x => x.MessageId).ToList();
            var incomingmessage = context.Messages.Count(x => x.Receiver == email).ToString();
            var outgoingmessage = context.Messages.Count(x => x.Sender == email).ToString();
            ViewBag.outgoingmessage = outgoingmessage;
            ViewBag.incomingmessage = incomingmessage;
            return View(messages);
        }
        public ActionResult DetailMessage(int id)
        {
            var values = context.Messages.Where(x => x.MessageId == id).ToList();
            var email = (string)Session["CustomerEmail"];
            var messages = context.Messages.Where(x => x.Sender == email).OrderByDescending(x => x.MessageId).ToList();
            var incomingmessage = context.Messages.Count(x => x.Receiver == email).ToString();
            var outgoingmessage = context.Messages.Count(x => x.Sender == email).ToString();
            ViewBag.outgoingmessage = outgoingmessage;
            ViewBag.incomingmessage = incomingmessage;
            var senderEmail = values.FirstOrDefault()?.Sender;
            var customer = context.Customers.FirstOrDefault(x => x.CustomerEmail == senderEmail);
            ViewBag.CustomerName = customer.CustomerName;
            ViewBag.CustomerSurname = customer.CustomerSurname;

            var receiverEmail = values.FirstOrDefault()?.Receiver;
            var receiver = context.Customers.FirstOrDefault(x => x.CustomerEmail == receiverEmail);
            if (receiver != null && receiver.CustomerName != null)
            {
                ViewBag.ReceiverName = receiver.CustomerName;
            }
            //ViewBag.ReceiverName = receiver.CustomerName;

            return View(values);
        }

        [HttpGet]
        public ActionResult AddMessage(int? id)
        {
            var values = context.Messages.Where(x => x.MessageId == id).ToList();
            var email = (string)Session["CustomerEmail"];
            var messages = context.Messages.Where(x => x.Sender == email).OrderByDescending(x => x.MessageId).ToList();
            var incomingmessage = context.Messages.Count(x => x.Receiver == email).ToString();
            var outgoingmessage = context.Messages.Count(x => x.Sender == email).ToString();
            ViewBag.outgoingmessage = outgoingmessage;
            ViewBag.incomingmessage = incomingmessage;

            var receiverEmail = values.FirstOrDefault()?.Receiver;
            var receiver = context.Customers.FirstOrDefault(x => x.CustomerEmail == receiverEmail);
            if (receiver != null && receiver.CustomerName != null)
            {
                ViewBag.ReceiverName = receiver.CustomerName;
            }
            //ViewBag.ReceiverName = receiver.CustomerName;
            //var receiver = context.Customers.FirstOrDefault(x => x.CustomerEmail == email);
            //ViewBag.ReceiverName = receiver.CustomerName;
            return View();
        }
        [HttpPost]
        public ActionResult AddMessage(Message message, int? id)
        {
            var email = (string)Session["CustomerEmail"];
            message.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.Sender = email;
            context.Messages.Add(message);
            context.SaveChanges();
            return View(message);
        }

        public ActionResult ShipmentTracking(string parameter = null)
        {
            var shipments = from x in context.ShipmentDetails select x;
            shipments = shipments.Where(y => y.ShippingCode.Contains(parameter));
            return View(shipments.ToList());
        }

        public ActionResult CustomerShipmentTracking(string id)
        {
            var values = context.ShipmentTrackings.Where(x => x.ShippingCode == id).ToList();
            return View(values);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public PartialViewResult SettingsPartial()
        {
            var email = (string)Session["CustomerEmail"];
            var id = context.Customers.Where(x => x.CustomerEmail == email).Select(y => y.CustomerId).FirstOrDefault();
            var findCustomer = context.Customers.Find(id);
            return PartialView("SettingsPartial", findCustomer);
        }
        public PartialViewResult TimelinePartial()
        {
            var values = context.Messages.Where(x => x.Sender == "admin").ToList();
            return PartialView(values);
        }
        public ActionResult CustomerSettingsUpdate(Customer c)
        {
            var customer = context.Customers.Find(c.CustomerId);
            customer.CustomerName= c.CustomerName;
            customer.CustomerSurname = c.CustomerSurname;
            customer.CustomerEmail= c.CustomerEmail;
            customer.CustomerPassword= c.CustomerPassword;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
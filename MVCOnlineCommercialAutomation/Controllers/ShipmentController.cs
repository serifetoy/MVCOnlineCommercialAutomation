using MVCOnlineCommercialAutomation.Models.Classes;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace MVCOnlineCommercialAutomation.Controllers
{
    public class ShipmentController : Controller
    {
        // GET: Shipment
        Context context = new Context();
        public ActionResult Index(string parameter = null)
        {
            var shipments = from x in context.ShipmentDetails select x;
            if (!string.IsNullOrEmpty(parameter))
            {
                shipments = shipments.Where(y => y.ShippingCode.Contains(parameter));

            }
            return View(shipments.ToList());

        }

        [HttpGet]
        public ActionResult AddShipment()
        {
            Random random = new Random();
            string[] characters = { "A", "B", "C", "D" };
            int n1 = random.Next(0, 4);
            int n2 = random.Next(0, 4);
            int n3 = random.Next(0, 4);
            int s1 = random.Next(100, 1000);
            int s2 = random.Next(10, 99);
            int s3 = random.Next(10, 99);
            string code = s1.ToString() + characters[n1] + s2 + characters[n2] + s3 + characters[n3];
            ViewBag.shipmentCode = code;

            return View();
        }

        [HttpPost]
        public ActionResult AddShipment(ShipmentDetail shipmentDetail)
        {
            context.ShipmentDetails.Add(shipmentDetail);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ShippingTrackingsDetail(string id)//its up to Route
        {
            var shipment = context.ShipmentTrackings.Where(x => x.ShippingCode == id).ToList();

            return View(shipment);

        }
    }
}
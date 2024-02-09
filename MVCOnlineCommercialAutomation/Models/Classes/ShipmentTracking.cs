using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineCommercialAutomation.Models.Classes
{
    public class ShipmentTracking
    {
        [Key]
        public int ShipmentTrackingId { get; set; }
        [Column(TypeName="Varchar")]
        [StringLength(10)]
        public string ShippingCode { get; set; }//123456AB
        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string Explanation { get; set; }
        public DateTime DateTime { get; set; }
    }
}
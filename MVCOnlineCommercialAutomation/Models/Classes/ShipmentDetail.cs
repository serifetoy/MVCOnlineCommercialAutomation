using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineCommercialAutomation.Models.Classes
{
    public class ShipmentDetail
    {
        [Key]
        public int ShipmentDetailId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(300)]
        public string Explanation { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string ShippingCode { get; set; }//123456AB
        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string Personnel { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(25)]
        public string Reciever { get; set; }
        public DateTime Date { get; set; }
    }
}
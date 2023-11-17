using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineCommercialAutomation.Models.Classes
{
    public class Payments//giderler
    {
        [Key]
        public int PaymentId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string Status { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Price  { get; set; }//fiyat
    }
}
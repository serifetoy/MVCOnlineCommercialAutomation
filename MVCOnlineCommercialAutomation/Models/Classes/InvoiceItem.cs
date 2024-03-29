﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineCommercialAutomation.Models.Classes
{
    public class InvoiceItem
    {
        [Key]
        public int InvoiceItemId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string Explanation { get; set; }
        public int Quantity{ get; set; }//miktar
        public decimal UnitPrice{ get; set; }
        public decimal Price{ get; set; }//fiyat
        public int InvoiceId { get; set; }
        public virtual Invoice Invoices { get; set; }

    }
}
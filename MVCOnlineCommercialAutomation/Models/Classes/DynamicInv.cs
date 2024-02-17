using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCOnlineCommercialAutomation.Models.Classes
{
    public class DynamicInv
    {
        public IEnumerable<Invoice> InvoiceValue { get; set; }
        public IEnumerable<InvoiceItem> InvoiceItemValue { get; set; }
    }
}
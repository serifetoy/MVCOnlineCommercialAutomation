using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCOnlineCommercialAutomation.Models.Classes
{
    public class ProductIntroduction
    {
        public IEnumerable<Product> ProductId { get; set; }
        public IEnumerable<DetailForProduct> DetailForProductId { get; set; }
    }
}
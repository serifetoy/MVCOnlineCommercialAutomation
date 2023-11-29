using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCOnlineCommercialAutomation.Models.Classes
{
    public class DetailForProduct
    {
        [Key]
        public int DetailForProductId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string DetailForProductName { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(2000)]
        public string DetailForProductInfo { get; set; }

    }
}
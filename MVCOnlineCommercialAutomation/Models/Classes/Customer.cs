using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineCommercialAutomation.Models.Classes
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string CustomerName { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string CustomerSurname { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(15)]
        public string CustomerCity { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string CustomerEmail { get; set; }
        public ICollection<SaleTransaction> SaleTransactions { get; set; }

    }
}
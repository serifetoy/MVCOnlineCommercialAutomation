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
        [StringLength(30, ErrorMessage = "Cannot exceed 30 characters")]
        public string CustomerName { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Required field cannot be left blank")]
        public string CustomerSurname { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(15)]
        public string CustomerCity { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string CustomerEmail { get; set; }

        public bool Status { get; set; }
        public ICollection<SaleTransaction> SaleTransactions { get; set; }

    }
}
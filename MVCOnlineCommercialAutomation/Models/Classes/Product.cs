using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineCommercialAutomation.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string ProductName { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Brand { get; set; }
        public short Stock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingePrice { get; set; }
        public bool Status { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(250)]
        public string ProductImage { get; set; }
        public virtual Category Category { get; set; }//her ürünün sadece 1 kategorisi vardır
        public int CategoryId { get; set; }
        public ICollection<SaleTransaction> SaleTransactions { get; set; }
    }
}
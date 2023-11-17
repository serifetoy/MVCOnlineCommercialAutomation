using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineCommercialAutomation.Models.Classes
{
    public class Category
    {
        //Contents of table are here
        [Key]
        public int CategoryId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string CategoryName { get; set; }
        //herbir kategoride birden fazla ürün var
        public ICollection<Product> Products { get; set; } 
    }
}
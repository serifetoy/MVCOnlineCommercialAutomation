using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCOnlineCommercialAutomation.Models.Classes
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string Sender { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string Receiver { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string Subject { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(2000)]
        public string Contents { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
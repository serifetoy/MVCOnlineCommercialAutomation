using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace MVCOnlineCommercialAutomation.Models.Classes
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string InvoiceSerialNo { get; set; }//fatura seri no
        [Column(TypeName = "VarChar")]
        [StringLength(6)]
        public string InvoiceSequenceNo { get; set; }//fatura sıra no
        [Column(TypeName = "VarChar")]
        [StringLength(60)]
        public string TaxAdministration { get; set; } //vergi dairesi
        public DateTime InvoiceDate { get; set; }
        public DateTime InvoiceTime { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Receiver { get; set;} //teslim alan 
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Deliverer { get; set;} //teslim eden
        public ICollection<InvoiceItem> InvoicesItems { get; set; }
    }
}
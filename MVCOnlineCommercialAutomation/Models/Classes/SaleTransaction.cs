using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCOnlineCommercialAutomation.Models.Classes
{
    public class SaleTransaction//satış harekketi
    {
        [Key]
        public int SaleTransactionId { get; set; }
        //ürün
        //cari-customer
        //personel
        public DateTime SaleTransactionDate { get; set; }
        public int Quantity { get; set; }//miktar
        public decimal Price { get; set; }//fiyat
        public decimal TotalAmount { get; set; }//toplam tutar
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
    }
}
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
        public ICollection<Product> Products { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
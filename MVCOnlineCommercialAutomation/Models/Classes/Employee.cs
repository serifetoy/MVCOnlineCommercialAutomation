using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineCommercialAutomation.Models.Classes
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string EmployeeName { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string EmployeeSurname { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(250)]
        public string EmployeeImage { get; set; }
        public SaleTransaction SaleTransaction { get; set; }

        public Department Department { get; set; } 
    }
}
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

        [Display(Name = "Employee Name")]
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string EmployeeName { get; set; }
        [Display(Name = "Employee Surname")]
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string EmployeeSurname { get; set; }
        [Display(Name = "Image")]
        [Column(TypeName = "VarChar")]
        [StringLength(250)]
        public string EmployeeImage { get; set; }
        public ICollection<SaleTransaction> SaleTransactions { get; set; }
        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
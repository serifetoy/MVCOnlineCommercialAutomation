using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineCommercialAutomation.Models.Classes
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string DepartmentName { get; set; }
        public bool Status { get; set; } = true;
        public ICollection<Employee> Employees { get; set;}
    }
}
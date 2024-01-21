using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCOnlineCommercialAutomation.Models.Classes
{
    public class ToDoClass
    {
        [Key]
        public int ToDoId { get; set; }
        
        [Column(TypeName = "VarChar")]
        [StringLength(150)]
        public string Header { get; set; }
        
        [Column(TypeName = "bit")]
        public bool Status { get; set; }
        
    }
}
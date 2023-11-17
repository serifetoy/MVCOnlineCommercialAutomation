using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineCommercialAutomation.Models.Classes
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string AdminName { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Password{ get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(5)]
        public string Authority { get; set; }//yetki
    }
}
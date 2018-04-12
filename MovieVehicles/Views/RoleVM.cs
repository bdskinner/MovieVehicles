using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieVehicles.Views
{
    public class RoleVM
    {
        public RoleVM()
        {
                
        }

        [Key]
        public int iD { get; set; }

        [Required]
        [Display(Name = "Role Name")]
        public string Name { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechInvMgmt.Models
{
    public class Subinventory
    {
        [Key]
        [Required]
        [Display(Name = "Subinventory")]
        public string Subinv { get; set; }

        [Required]
        [Display(Name = "Assigned Tech")]
        public string AssignedTech { get; set; }
    }
}

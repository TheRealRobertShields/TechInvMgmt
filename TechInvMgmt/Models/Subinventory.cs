using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechInvMgmt.Models
{
    /// <summary>
    /// A single sub-inventory.
    /// </summary>
    public class Subinventory
    {
        [Key]
        [Display(Name = "Subinventory")]
        public string SubInv { get; set; }

    }
}

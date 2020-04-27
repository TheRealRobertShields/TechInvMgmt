using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechInvMgmt.Models
{
    /// <summary>
    /// The list of all parts and which subinventories they are located in.
    /// </summary>
    public class Inventory
    {
        [Key]
        public int RowId { get; set; }

        [Required]
        [Display(Name = "Subinventory")]
        public string Subinventory { get; set; }

        [Required]
        [Display(Name = "Part Number")]
        public string PartNumber { get; set; }

        [Required]
        [Display(Name = "Part Name")]
        public string PartName { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}

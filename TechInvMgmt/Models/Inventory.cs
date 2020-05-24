using Microsoft.AspNetCore.Mvc;
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
        [Required]
        public string InventoryId { get; set; }

        [Required]
        [Display(Name = "Subinventory")]
        [ForeignKey("SubinventoryId")]
        public string SubinventoryId { get; set; }

        [Required]
        [Display(Name = "PartId")]
        [ForeignKey("PartId")]
        public string PartId { get; set; }

        [Required]
        [Range(0, Double.PositiveInfinity)]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

    }
}

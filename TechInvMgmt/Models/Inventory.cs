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
        [Display(Name = "Inventory Id")]
        public string InventoryId { get; set; }

        [Required]
        [Display(Name = "Subinv")]
        public string SubinventoryId { get; set; }

        [Required]
        [Display(Name = "Part")]
        public string PartId { get; set; }

        [Required]
        [Range(0, Double.PositiveInfinity)]
        [Display(Name = "Qty")]
        public int Quantity { get; set; }

    }
}

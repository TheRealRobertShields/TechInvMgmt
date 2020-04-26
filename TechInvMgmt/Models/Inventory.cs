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

        public Part Part { get; set; }

        public Subinventory Subinv { get; set; }

        public int Quantity { get; set; }
    }
}

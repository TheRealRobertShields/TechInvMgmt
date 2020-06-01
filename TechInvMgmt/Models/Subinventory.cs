using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TechInvMgmt.Data;

namespace TechInvMgmt.Models
{
    public class Subinventory
    {
        [Key]
        [Required]
        public string SubinventoryId { get; set; }

        [ForeignKey("Id")]
        public string EmployeeId { get; set; }

        public override string ToString()
        {
            return $"{SubinventoryId}".ToUpper();
        }

    }
}

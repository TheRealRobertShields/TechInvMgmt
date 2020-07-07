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
        [Display(Name = "Subinventory")]
        public string SubinventoryId { get; set; }


        [Display(Name ="Employee")]
        public string EmployeeId { get; set; }

        public override string ToString()
        {
            return $"{SubinventoryId}".ToUpper();
        }

    }
}

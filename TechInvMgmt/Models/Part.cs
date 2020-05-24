using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechInvMgmt.Models
{
    /// <summary>
    /// Represents a single part.
    /// </summary>
    public class Part
    {
        /// <summary>
        /// The unique id for the part.
        /// </summary>
        [Key]
        [Required]
        [Display(Name = "Number")]
        public string PartId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string PartName { get; set; }

        [Display(Name = "Description")]
        public string PartDescription { get; set; }

        [Display(Name = "Category")]
        public string PartCategory { get; set; }

        [Required]
        [Display(Name = "Is serialized?")]
        public bool PartIsSerialized { get; set; }

        public override string ToString()
        {
            return $"{PartId} {PartName}".ToUpper();
        }
    }
}

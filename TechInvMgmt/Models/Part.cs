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
        public string Number { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }

        [Required]
        [Display(Name = "Is serialized?")]
        public bool IsSerialized { get; set; }

        public override string ToString()
        {
            return $"{Number} {Name}";
        }
    }
}

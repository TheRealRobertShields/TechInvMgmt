using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechInvMgmt.Models
{
    public class SerialNumber
    {
        [Key]
        [Required]
        [Display(Name = "SN")]
        public string SerialNumberId { get; set; }


        [Required]
        [Display(Name = "Part")]
        public string PartId { get; set; }


        [Required]
        [Display(Name = "Subinv")]
        public string SubinventoryId { get; set; }

        [Required]
        [Display(Name = "CustomInventory Id")]
        public string CustomInventoryId { get; set; }

        public override string ToString()
        {
            return $"{SerialNumberId}".ToUpper();
        }
    }
}
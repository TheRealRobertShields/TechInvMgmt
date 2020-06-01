using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechInvMgmt.Models
{
    public class SerialNumber
    {
        [Key]
        [Required]
        public string SerialNumberId { get; set; }

        [ForeignKey("PartId")]
        [Required]
        public string PartId { get; set; }

        [ForeignKey("SubinventoryId")]
        [Required]
        public string SubinventoryId { get; set; }

        [Required]
        public string CustomInventoryId { get; set; }

        public override string ToString()
        {
            return $"{SerialNumberId}".ToUpper();
        }
    }
}
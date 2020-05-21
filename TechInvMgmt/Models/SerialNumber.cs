using System.ComponentModel.DataAnnotations;

namespace TechInvMgmt.Models
{
    public class SerialNumber
    {
        [Key]
        public string SerialNum { get; set; }

        public string PartNum { get; set; }

        public string Subinv { get; set; }

        public string CustomInventoryId { get; set; }

        public override string ToString()
        {
            return $"{SerialNum}".ToUpper();
        }
    }
}
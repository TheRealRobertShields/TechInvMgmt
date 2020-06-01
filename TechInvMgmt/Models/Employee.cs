using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechInvMgmt.Models
{
    public class Employee : IdentityUser
    {

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [ForeignKey("SubinventoryId")]
        [Required]
        public string SubinventoryId { get; set; }

        [Required]
        public string AccountType { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}".ToUpper();
        }
    }
}

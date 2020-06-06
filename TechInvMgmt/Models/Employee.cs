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
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Subinventory")]
        public string SubinventoryId { get; set; }

        [Required]
        [Display(Name = "Account Type")]
        public string AccountType { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}".ToUpper();
        }
    }
}

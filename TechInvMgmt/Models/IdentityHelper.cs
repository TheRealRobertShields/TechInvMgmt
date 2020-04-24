using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechInvMgmt.Models
{
    public class IdentityHelper
    {
        public static void SetIdentityOptions(IdentityOptions idOptions)
        {
            // Set sign in options
            idOptions.SignIn.RequireConfirmedAccount = false;
            idOptions.SignIn.RequireConfirmedEmail = false;
            idOptions.SignIn.RequireConfirmedPhoneNumber = false;

            // Set password options
            idOptions.Password.RequiredLength = 8;
            idOptions.Password.RequireNonAlphanumeric = false;

            // Set lockout options
            idOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            idOptions.Lockout.MaxFailedAccessAttempts = 5;
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechInvMgmt.Models
{
    public class IdentityHelper
    {
        public const string Technician = "Technician";
        public const string ISP = "ISP";
        public const string FSM = "FSM";
        public const string Admin = "Admin";

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

        public static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            RoleManager<IdentityRole> roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

            // Create role if it does not exist
            foreach (string role in roles)
            {
                bool doesRoleExist = await roleManager.RoleExistsAsync(role);
                if (!doesRoleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}

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

        public static async Task CreateDefaultAdmin(IServiceProvider serviceProvider)
        {
            const string email = "techinvmgmt@tim.com";
            const string username = "admin";
            const string password = "Admin1!!";

            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Check if any users are in the DB
            if (userManager.Users.Count() == 0)
            {
                IdentityUser admin = new IdentityUser()
                {
                    Email = email,
                    UserName = username
                };

                // Create admin
                await userManager.CreateAsync(admin, password);

                // Add to admin role
                await userManager.AddToRoleAsync(admin, Admin);
            }
        }
    }
}

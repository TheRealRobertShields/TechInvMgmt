using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechInvMgmt.Models;

namespace TechInvMgmt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Subinventory> Subinventories { get; set; }

        public DbSet<Inventory> Inventory { get; set; }
    }
}

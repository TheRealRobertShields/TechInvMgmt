using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechInvMgmt.Models;

namespace TechInvMgmt.Data
{
    public class SubinventoryDb
    {
        public static async Task<List<Subinventory>> GetSubinvParts(ApplicationDbContext context)
        {
            return await (from subinv in context.Subinventories
                          select subinv).ToListAsync();
        }
    }
}

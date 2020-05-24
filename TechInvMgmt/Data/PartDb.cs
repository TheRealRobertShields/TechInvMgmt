using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechInvMgmt.Models;

namespace TechInvMgmt.Data
{
    public class PartDb
    {

        public static async Task<List<Part>> GetPartsAsync(ApplicationDbContext context)
        {
            List<Part> parts = await context.Parts.OrderBy(p => p.PartId).ToListAsync();
            return parts;
        }


    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechInvMgmt.Models;

namespace TechInvMgmt.Data
{
    public class InventoryDb
    {
           
        public static async Task<List<Inventory>> GetInvById(string subinv, ApplicationDbContext context)
        {

            return await (from inv in context.Inventory
                          where inv.SubinventoryId == subinv
                          select inv).ToListAsync();

        }
                         

        public static int GetNumOfSNsNeeded(int howManyTechSaysHeHas, int howManyTechEntered)
        {
            return howManyTechSaysHeHas - howManyTechEntered;
        }
    }
}

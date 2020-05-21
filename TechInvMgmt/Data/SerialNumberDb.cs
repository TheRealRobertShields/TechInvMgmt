using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechInvMgmt.Models;

namespace TechInvMgmt.Data
{
    public class SerialNumberDb
    {
        public static async Task<List<SerialNumber>> GetSNById(string customInvId, ApplicationDbContext context)
        {

            return await (from serial in context.SerialNumbers
                            where serial.CustomInventoryId == customInvId
                            select serial).ToListAsync();
            
        }
    }
}

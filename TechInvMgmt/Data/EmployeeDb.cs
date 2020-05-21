using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechInvMgmt.Models;

namespace TechInvMgmt.Data
{
    public class EmployeeDb
    {

        public static async Task<List<Employee>> GetEmployeesAsync(ApplicationDbContext context)
        {
            List<Employee> employees = await context.Employees.OrderBy(e => e.Id).ToListAsync();
            return employees;
        }


    }
}

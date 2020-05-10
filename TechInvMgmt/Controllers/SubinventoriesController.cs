using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechInvMgmt.Data;
using TechInvMgmt.Models;

namespace TechInvMgmt.Controllers
{
    public class SubinventoriesController : Controller
    {


        private readonly ApplicationDbContext _context;

        public SubinventoriesController(ApplicationDbContext context)
        {
            _context = context;
        }


        [AllowAnonymous]
        public async Task<IActionResult> Subinventories()
        {
            List<Employee> employees = new List<Employee>();

            employees = await (from e in _context.Employees
                               select e).ToListAsync();
            employees.Insert(0, new Employee { Subinventory = "0", FirstName = "Select" });

            ViewBag.ListofEmployees = employees;


            return View(await _context.Employees.ToListAsync());
        }

        // GET: Subinventory/Edit/5
        [HttpGet]
        public async Task<IActionResult> SubinventoriesEdit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeId = await _context.Employees.FindAsync(id);
            if (employeeId == null)
            {
                return NotFound();
            }
            return View(employeeId);
        }

        // POST: Subinventory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubinventoriesEdit(Employee employee)
        {
            var user = await _context.Employees.FindAsync(employee.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {employee.Id} cannot be found";
                return NotFound();
            }
            else
            {
                user.Subinventory = employee.Subinventory;
                user.FirstName = employee.FirstName;
                user.LastName = employee.LastName;

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(user);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!_context.Employees.Any(e => e.Id == employee.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Subinventories));
                }
                return View(user);
            }
        }
    }
}
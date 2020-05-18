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
    [Authorize(Roles = "ISP, FSM, Admin")]
    public class EmployeesController : Controller
    {


        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }


        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            List<Employee> employees = new List<Employee>();

            employees = await (from e in _context.Employees
                               select e).ToListAsync();
            employees.Insert(0, new Employee { Subinventory = "0", FirstName = "Select" });

            ViewBag.ListofEmployees = employees;


            return View(await _context.Employees.ToListAsync());
        }

        // GET: /Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
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

        // POST: /Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee employee)
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
                    return RedirectToAction(nameof(Index));
                }
                return View(user);
            }
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechInvMgmt.Data;
using TechInvMgmt.Models;

namespace TechInvMgmt.Controllers
{
    [Authorize(Roles = "ISP, Tech, FSM, Admin")]
    public class SubinventoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubinventoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult SubinvMenu()
        {
            return View();
        }

        // GET: Subinventories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Subinventories.ToListAsync());
        }

        // GET: Subinventories/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subinventory = await _context.Subinventories
                .FirstOrDefaultAsync(m => m.SubinventoryId == id);
            if (subinventory == null)
            {
                return NotFound();
            }

            return View(subinventory);
        }

        [Authorize(Roles = "ISP, FSM, Admin")]
        // GET: Subinventories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subinventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ISP, FSM, Admin")]
        public async Task<IActionResult> Create([Bind("SubinventoryId,EmployeeId")] Subinventory subinventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subinventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subinventory);
        }

        // GET: Subinventories/Edit/5
        [Authorize(Roles = "ISP, FSM, Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subinventory = await _context.Subinventories.FindAsync(id);
            if (subinventory == null)
            {
                return NotFound();
            }
            return View(subinventory);
        }

        // POST: Subinventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ISP, FSM, Admin")]
        public async Task<IActionResult> Edit(string id, [Bind("SubinventoryId,EmployeeId")] Subinventory subinventory)
        {
            if (id != subinventory.SubinventoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subinventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubinventoryExists(subinventory.SubinventoryId))
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
            return View(subinventory);
        }




        // GET: Subinventories/Delete/5
        [Authorize(Roles = "ISP, FSM, Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subinventory = await _context.Subinventories
                .FirstOrDefaultAsync(m => m.SubinventoryId == id);
            if (subinventory == null)
            {
                return NotFound();
            }

            return View(subinventory);
        }

        // POST: Subinventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ISP, FSM, Admin")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var subinventory = await _context.Subinventories.FindAsync(id);
            _context.Subinventories.Remove(subinventory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubinventoryExists(string id)
        {
            return _context.Subinventories.Any(e => e.SubinventoryId == id);
        }
    }
}

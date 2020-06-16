using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechInvMgmt.Data;
using TechInvMgmt.Models;

namespace TechInvMgmt.Controllers
{
    [Authorize(Roles = "ISP, Admin, Tech")]
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Inventory
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            List<Part> partsList = new List<Part>();

            partsList = await (from part in _context.Parts
                               select part).ToListAsync();
            partsList.Insert(0, new Part { PartId = "", PartName = "Select" });

            ViewBag.ListofParts = partsList;


            return View(await _context.Inventory.ToListAsync());
        }

        // GET: Inventory
        [AllowAnonymous]
        public IActionResult InvMenu()
        {
            return View();
        }


        public async Task<IActionResult> MyInventory()
        {
            var emp = User.Identity.Name;
            string subinv = "RobertIsTheBest";
            foreach (Employee employee in await _context.Employees.ToListAsync())
            {
                if (employee.UserName == User.Identity.Name)
                {
                    subinv = employee.SubinventoryId;
                }
            }
            List<Inventory> subinvParts = new List<Inventory>();
            subinvParts = await (from inv in _context.Inventory where inv.SubinventoryId == subinv
                                 select inv).ToListAsync();
            return View(subinvParts);
        }
        public async Task<IActionResult> ReplenishList()
        {
            return View();
        }


        // GET: Inventory/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory
                .FirstOrDefaultAsync(m => m.InventoryId == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // GET: Inventory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InventoryId,SubinventoryId,PartId,Quantity")] Inventory inventory)
        {

            var inv = await _context.Inventory
                .FirstOrDefaultAsync(i => i.InventoryId == inventory.InventoryId);
            if (inv != null)
            {
                TempData["Message"] = $"{inventory.SubinventoryId} already has {inventory.PartId}s.\nTo edit the quantity of that part, ";
                return View(inventory);
            }

            if (ModelState.IsValid)
            {
                _context.Add(inventory);
                await _context.SaveChangesAsync();
                TempData["Message"] = $"{inventory.Quantity} {inventory.PartId}s added to {inventory.SubinventoryId}.";
                return RedirectToAction(nameof(Index));
            }
            return View(inventory);
        }

        // GET: Inventory/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var inventory = await _context.Inventory.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return View(inventory);
        }

        // POST: Inventory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("InventoryId,SubinventoryId,PartId,Quantity")] Inventory inventory)
        {
            if (id != inventory.InventoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryExists(inventory.InventoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["Message"] = $"Changes Saved!";
                return RedirectToAction(nameof(Edit));
            }
            return View(inventory);
        }

        [Authorize(Roles ="ISP,Admin")]
        // GET: Inventory/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory
                .FirstOrDefaultAsync(m => m.InventoryId == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        [Authorize(Roles = "ISP,Admin")]
        // POST: Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var inventory = await _context.Inventory.FindAsync(id);
            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryExists(string id)
        {
            return _context.Inventory.Any(e => e.InventoryId == id);
        }
    }
}

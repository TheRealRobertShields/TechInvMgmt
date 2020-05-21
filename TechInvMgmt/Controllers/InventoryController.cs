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
            partsList.Insert(0, new Part { Number = "0", Name = "Select" });

            ViewBag.ListofParts = partsList;


            return View(await _context.Inventory.ToListAsync());
        }

        // GET: Inventory
        [AllowAnonymous]
        public async Task<IActionResult> SubIndex(string subinv)
        {
            subinv = "REMVAN11";
            List<Inventory> inventories = new List<Inventory>();

            inventories = await (from inv in _context.Inventory
                   where inv.Subinventory == subinv
                   select inv).ToListAsync();


            return View(inventories);
        }





        // GET: Inventory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory
                .FirstOrDefaultAsync(m => m.RowId == id);
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
        public async Task<IActionResult> Create([Bind("RowId,Subinventory,PartNumber,PartName,Quantity,CustomInventoryId")] Inventory inventory)
        {

            var inv = await _context.Inventory
                .FirstOrDefaultAsync(i => i.CustomInventoryId == inventory.CustomInventoryId);
            if (inv != null)
            {
                TempData["Message"] = $"{inventory.Subinventory} already has {inventory.PartName}s.\nTo edit the quantity of that part, ";
                return View(inventory);
            }

            if (ModelState.IsValid)
            {
                _context.Add(inventory);
                await _context.SaveChangesAsync();
                TempData["Message"] = $"{inventory.Quantity} {inventory.PartName}s added to {inventory.Subinventory}.";
                return RedirectToAction(nameof(Index));
            }
            return View(inventory);
        }

        // GET: Inventory/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
        public async Task<IActionResult> Edit(int id, [Bind("RowId,Subinventory,PartNumber,PartName,Quantity,CustomInventoryId")] Inventory inventory)
        {
            if (id != inventory.RowId)
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
                    if (!InventoryExists(inventory.RowId))
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
            return View(inventory);
        }

        [Authorize(Roles ="ISP,Admin")]
        // GET: Inventory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory
                .FirstOrDefaultAsync(m => m.RowId == id);
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventory = await _context.Inventory.FindAsync(id);
            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventory.Any(e => e.RowId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechInvMgmt.Data;
using TechInvMgmt.Models;

namespace TechInvMgmt.Controllers
{
    public class SerialNumbersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SerialNumbersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SerialNumbers
        public async Task<IActionResult> Index()
        {
            return View(await _context.SerialNumbers.ToListAsync());
        }

        // GET: SerialNumbers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serialNumber = await _context.SerialNumbers
                .FirstOrDefaultAsync(m => m.SerialNum == id);
            if (serialNumber == null)
            {
                return NotFound();
            }

            return View(serialNumber);
        }

        // GET: SerialNumbers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SerialNumbers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SerialNum,PartNum,Subinv")] SerialNumber serialNumber)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serialNumber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serialNumber);
        }

        // GET: SerialNumbers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serialNumber = await _context.SerialNumbers.FindAsync(id);
            if (serialNumber == null)
            {
                return NotFound();
            }
            return View(serialNumber);
        }

        // POST: SerialNumbers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SerialNum,PartNum,Subinv")] SerialNumber serialNumber)
        {
            if (id != serialNumber.SerialNum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serialNumber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SerialNumberExists(serialNumber.SerialNum))
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
            return View(serialNumber);
        }

        // GET: SerialNumbers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serialNumber = await _context.SerialNumbers
                .FirstOrDefaultAsync(m => m.SerialNum == id);
            if (serialNumber == null)
            {
                return NotFound();
            }

            return View(serialNumber);
        }

        // POST: SerialNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var serialNumber = await _context.SerialNumbers.FindAsync(id);
            _context.SerialNumbers.Remove(serialNumber);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SerialNumberExists(string id)
        {
            return _context.SerialNumbers.Any(e => e.SerialNum == id);
        }
    }
}

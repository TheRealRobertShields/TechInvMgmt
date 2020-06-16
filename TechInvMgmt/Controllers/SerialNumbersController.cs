using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechInvMgmt.Data;
using TechInvMgmt.Models;

namespace TechInvMgmt.Controllers
{
    [Authorize(Roles = "ISP, Tech, Admin")]
    public class SerialNumbersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SerialNumbersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult SNMenu()
        {
            return View();
        }

        // GET: SerialNumbers
        public async Task<IActionResult> Index()
        {
            return View(await _context.SerialNumbers.ToListAsync());
        }

        // GET: SerialNumbers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var serialNumber = await _context.SerialNumbers
                .FirstOrDefaultAsync(m => m.SerialNumberId == id);
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
        public async Task<IActionResult> Create([Bind("SerialNumberId,PartId,SubinventoryId,CustomInventoryId")] SerialNumber serialNumber)
        {
            serialNumber.SerialNumberId = serialNumber.SerialNumberId.ToUpper();
            if (ModelState.IsValid)
            {
                TempData["Message"] = serialNumber.SerialNumberId;
                _context.Add(serialNumber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
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
        public async Task<IActionResult> Edit(string id, [Bind("SerialNumberId,PartId,SubinventoryId,CustomInventoryId")] SerialNumber serialNumber)
        {
            serialNumber.SerialNumberId = serialNumber.SerialNumberId.ToUpper();
            if (id != serialNumber.SerialNumberId)
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
                    if (!SerialNumberExists(serialNumber.SerialNumberId))
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
                .FirstOrDefaultAsync(m => m.SerialNumberId == id);
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

            string returnUrl = HttpUtility.UrlDecode(Request.QueryString.ToString());

            return RedirectToAction(nameof(Index));
        }

        private bool SerialNumberExists(string id)
        {
            return _context.SerialNumbers.Any(e => e.SerialNumberId == id);
        }
    }
}

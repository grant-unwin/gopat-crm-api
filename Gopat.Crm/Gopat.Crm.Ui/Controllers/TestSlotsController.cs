using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gopat.Crm.Models;

namespace Gopat.Crm.Ui.Controllers
{
    public class TestSlotsController : Controller
    {
        private readonly GopatContext _context;

        public TestSlotsController(GopatContext context)
        {
            _context = context;
        }

        // GET: TestSlots
        public async Task<IActionResult> Index()
        {
            var gopatContext = _context.TestSlots.Include(t => t.Contract).Include(t => t.Site);
            return View(await gopatContext.ToListAsync());
        }

        // GET: TestSlots/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testSlot = await _context.TestSlots
                .Include(t => t.Contract)
                .Include(t => t.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testSlot == null)
            {
                return NotFound();
            }

            return View(testSlot);
        }

        // GET: TestSlots/Create
        public IActionResult Create()
        {
            ViewData["ContractId"] = new SelectList(_context.Contracts, "Id", "Id");
            ViewData["SiteId"] = new SelectList(_context.Sites, "Id", "Id");
            return View();
        }

        // POST: TestSlots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SiteId,ContractId,ScheduledDateTime,EstimatedDurationMins,ActualDurationMins,EstimatedAppliances,ActualAppliances,TestSlowResult,Id,Created,Modified")] TestSlot testSlot)
        {
            if (ModelState.IsValid)
            {
                testSlot.Id = Guid.NewGuid();
                _context.Add(testSlot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContractId"] = new SelectList(_context.Contracts, "Id", "Id", testSlot.ContractId);
            ViewData["SiteId"] = new SelectList(_context.Sites, "Id", "Id", testSlot.SiteId);
            return View(testSlot);
        }

        // GET: TestSlots/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testSlot = await _context.TestSlots.FindAsync(id);
            if (testSlot == null)
            {
                return NotFound();
            }
            ViewData["ContractId"] = new SelectList(_context.Contracts, "Id", "Id", testSlot.ContractId);
            ViewData["SiteId"] = new SelectList(_context.Sites, "Id", "Id", testSlot.SiteId);
            return View(testSlot);
        }

        // POST: TestSlots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("SiteId,ContractId,ScheduledDateTime,EstimatedDurationMins,ActualDurationMins,EstimatedAppliances,ActualAppliances,TestSlowResult,Id,Created,Modified")] TestSlot testSlot)
        {
            if (id != testSlot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testSlot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestSlotExists(testSlot.Id))
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
            ViewData["ContractId"] = new SelectList(_context.Contracts, "Id", "Id", testSlot.ContractId);
            ViewData["SiteId"] = new SelectList(_context.Sites, "Id", "Id", testSlot.SiteId);
            return View(testSlot);
        }

        // GET: TestSlots/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testSlot = await _context.TestSlots
                .Include(t => t.Contract)
                .Include(t => t.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testSlot == null)
            {
                return NotFound();
            }

            return View(testSlot);
        }

        // POST: TestSlots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var testSlot = await _context.TestSlots.FindAsync(id);
            _context.TestSlots.Remove(testSlot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestSlotExists(Guid id)
        {
            return _context.TestSlots.Any(e => e.Id == id);
        }
    }
}

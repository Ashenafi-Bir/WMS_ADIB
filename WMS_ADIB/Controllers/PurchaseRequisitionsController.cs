using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WMS_ADIB.Data;
using WMS_ADIB.Models;

namespace WMS_ADIB.Controllers
{
    public class PurchaseRequisitionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchaseRequisitionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PurchaseRequisitions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PurchaseRequisitions.Include(p => p.PurchaseRequstionAuthorizedBy).Include(p => p.PurchaseRequstionRequestedByUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PurchaseRequisitions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseRequisition = await _context.PurchaseRequisitions
                .Include(p => p.PurchaseRequstionAuthorizedBy)
                .Include(p => p.PurchaseRequstionRequestedByUser)
                .FirstOrDefaultAsync(m => m.PRNumber == id);
            if (purchaseRequisition == null)
            {
                return NotFound();
            }

            return View(purchaseRequisition);
        }

        // GET: PurchaseRequisitions/Create
        public IActionResult Create()
        {
            ViewData["PurchaseRequstionAuthorizedById"] = new SelectList(_context.Users, "UserID", "Role");
            ViewData["PurchaseRequstionRequestedByUserId"] = new SelectList(_context.Users, "UserID", "Role");
            return View();
        }

        // POST: PurchaseRequisitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PRNumber,Date,PurchaseRequstionRequestedByUserId,PurchaseRequstionAuthorizedById")] PurchaseRequisition purchaseRequisition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseRequisition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PurchaseRequstionAuthorizedById"] = new SelectList(_context.Users, "UserID", "Role", purchaseRequisition.PurchaseRequstionAuthorizedById);
            ViewData["PurchaseRequstionRequestedByUserId"] = new SelectList(_context.Users, "UserID", "Role", purchaseRequisition.PurchaseRequstionRequestedByUserId);
            return View(purchaseRequisition);
        }

        // GET: PurchaseRequisitions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseRequisition = await _context.PurchaseRequisitions.FindAsync(id);
            if (purchaseRequisition == null)
            {
                return NotFound();
            }
            ViewData["PurchaseRequstionAuthorizedById"] = new SelectList(_context.Users, "UserID", "Role", purchaseRequisition.PurchaseRequstionAuthorizedById);
            ViewData["PurchaseRequstionRequestedByUserId"] = new SelectList(_context.Users, "UserID", "Role", purchaseRequisition.PurchaseRequstionRequestedByUserId);
            return View(purchaseRequisition);
        }

        // POST: PurchaseRequisitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PRNumber,Date,PurchaseRequstionRequestedByUserId,PurchaseRequstionAuthorizedById")] PurchaseRequisition purchaseRequisition)
        {
            if (id != purchaseRequisition.PRNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseRequisition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseRequisitionExists(purchaseRequisition.PRNumber))
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
            ViewData["PurchaseRequstionAuthorizedById"] = new SelectList(_context.Users, "UserID", "Role", purchaseRequisition.PurchaseRequstionAuthorizedById);
            ViewData["PurchaseRequstionRequestedByUserId"] = new SelectList(_context.Users, "UserID", "Role", purchaseRequisition.PurchaseRequstionRequestedByUserId);
            return View(purchaseRequisition);
        }

        // GET: PurchaseRequisitions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseRequisition = await _context.PurchaseRequisitions
                .Include(p => p.PurchaseRequstionAuthorizedBy)
                .Include(p => p.PurchaseRequstionRequestedByUser)
                .FirstOrDefaultAsync(m => m.PRNumber == id);
            if (purchaseRequisition == null)
            {
                return NotFound();
            }

            return View(purchaseRequisition);
        }

        // POST: PurchaseRequisitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseRequisition = await _context.PurchaseRequisitions.FindAsync(id);
            if (purchaseRequisition != null)
            {
                _context.PurchaseRequisitions.Remove(purchaseRequisition);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseRequisitionExists(int id)
        {
            return _context.PurchaseRequisitions.Any(e => e.PRNumber == id);
        }
    }
}

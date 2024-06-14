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
    public class AssetDisposalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssetDisposalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AssetDisposals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AssetDisposals.Include(a => a.Branch).Include(a => a.DisposalApprovedBy).Include(a => a.DisposedBy).Include(a => a.Item);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AssetDisposals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetDisposal = await _context.AssetDisposals
                .Include(a => a.Branch)
                .Include(a => a.DisposalApprovedBy)
                .Include(a => a.DisposedBy)
                .Include(a => a.Item)
                .FirstOrDefaultAsync(m => m.DisposalID == id);
            if (assetDisposal == null)
            {
                return NotFound();
            }

            return View(assetDisposal);
        }

        // GET: AssetDisposals/Create
        public IActionResult Create()
        {
            ViewData["BranchID"] = new SelectList(_context.Branches, "BranchID", "BranchName");
            ViewData["DisposalApprovedByUserID"] = new SelectList(_context.Users, "UserID", "Role");
            ViewData["DisposedByUserID"] = new SelectList(_context.Users, "UserID", "Role");
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "Description");
            return View();
        }

        // POST: AssetDisposals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DisposalID,ItemID,Quantity,DateDisposed,Reason,BranchID,DisposedByUserID,DisposalApprovedByUserID")] AssetDisposal assetDisposal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assetDisposal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchID"] = new SelectList(_context.Branches, "BranchID", "BranchName", assetDisposal.BranchID);
            ViewData["DisposalApprovedByUserID"] = new SelectList(_context.Users, "UserID", "Role", assetDisposal.DisposalApprovedByUserID);
            ViewData["DisposedByUserID"] = new SelectList(_context.Users, "UserID", "Role", assetDisposal.DisposedByUserID);
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "Description", assetDisposal.ItemID);
            return View(assetDisposal);
        }

        // GET: AssetDisposals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetDisposal = await _context.AssetDisposals.FindAsync(id);
            if (assetDisposal == null)
            {
                return NotFound();
            }
            ViewData["BranchID"] = new SelectList(_context.Branches, "BranchID", "BranchName", assetDisposal.BranchID);
            ViewData["DisposalApprovedByUserID"] = new SelectList(_context.Users, "UserID", "Role", assetDisposal.DisposalApprovedByUserID);
            ViewData["DisposedByUserID"] = new SelectList(_context.Users, "UserID", "Role", assetDisposal.DisposedByUserID);
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "Description", assetDisposal.ItemID);
            return View(assetDisposal);
        }

        // POST: AssetDisposals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DisposalID,ItemID,Quantity,DateDisposed,Reason,BranchID,DisposedByUserID,DisposalApprovedByUserID")] AssetDisposal assetDisposal)
        {
            if (id != assetDisposal.DisposalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assetDisposal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetDisposalExists(assetDisposal.DisposalID))
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
            ViewData["BranchID"] = new SelectList(_context.Branches, "BranchID", "BranchName", assetDisposal.BranchID);
            ViewData["DisposalApprovedByUserID"] = new SelectList(_context.Users, "UserID", "Role", assetDisposal.DisposalApprovedByUserID);
            ViewData["DisposedByUserID"] = new SelectList(_context.Users, "UserID", "Role", assetDisposal.DisposedByUserID);
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "Description", assetDisposal.ItemID);
            return View(assetDisposal);
        }

        // GET: AssetDisposals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetDisposal = await _context.AssetDisposals
                .Include(a => a.Branch)
                .Include(a => a.DisposalApprovedBy)
                .Include(a => a.DisposedBy)
                .Include(a => a.Item)
                .FirstOrDefaultAsync(m => m.DisposalID == id);
            if (assetDisposal == null)
            {
                return NotFound();
            }

            return View(assetDisposal);
        }

        // POST: AssetDisposals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assetDisposal = await _context.AssetDisposals.FindAsync(id);
            if (assetDisposal != null)
            {
                _context.AssetDisposals.Remove(assetDisposal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetDisposalExists(int id)
        {
            return _context.AssetDisposals.Any(e => e.DisposalID == id);
        }
    }
}

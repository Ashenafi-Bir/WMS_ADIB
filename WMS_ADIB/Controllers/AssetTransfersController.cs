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
    public class AssetTransfersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssetTransfersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AssetTransfers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AssetTransfers.Include(a => a.AssetTransferAuthorizedByUser).Include(a => a.FromBranch).Include(a => a.Item).Include(a => a.ToBranch);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AssetTransfers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetTransfer = await _context.AssetTransfers
                .Include(a => a.AssetTransferAuthorizedByUser)
                .Include(a => a.FromBranch)
                .Include(a => a.Item)
                .Include(a => a.ToBranch)
                .FirstOrDefaultAsync(m => m.TransferID == id);
            if (assetTransfer == null)
            {
                return NotFound();
            }

            return View(assetTransfer);
        }

        // GET: AssetTransfers/Create
        public IActionResult Create()
        {
            ViewData["AssetTransferAuthorizedByUserID"] = new SelectList(_context.Users, "UserID", "Role");
            ViewData["FromBranchID"] = new SelectList(_context.Branches, "BranchID", "BranchName");
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "Description");
            ViewData["ToBranchID"] = new SelectList(_context.Branches, "BranchID", "BranchName");
            return View();
        }

        // POST: AssetTransfers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransferID,FromBranchID,ToBranchID,ItemID,Quantity,DateTransferred,Status,AssetTransferAuthorizedByUserID")] AssetTransfer assetTransfer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assetTransfer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetTransferAuthorizedByUserID"] = new SelectList(_context.Users, "UserID", "Role", assetTransfer.AssetTransferAuthorizedByUserID);
            ViewData["FromBranchID"] = new SelectList(_context.Branches, "BranchID", "BranchName", assetTransfer.FromBranchID);
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "Description", assetTransfer.ItemID);
            ViewData["ToBranchID"] = new SelectList(_context.Branches, "BranchID", "BranchName", assetTransfer.ToBranchID);
            return View(assetTransfer);
        }

        // GET: AssetTransfers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetTransfer = await _context.AssetTransfers.FindAsync(id);
            if (assetTransfer == null)
            {
                return NotFound();
            }
            ViewData["AssetTransferAuthorizedByUserID"] = new SelectList(_context.Users, "UserID", "Role", assetTransfer.AssetTransferAuthorizedByUserID);
            ViewData["FromBranchID"] = new SelectList(_context.Branches, "BranchID", "BranchName", assetTransfer.FromBranchID);
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "Description", assetTransfer.ItemID);
            ViewData["ToBranchID"] = new SelectList(_context.Branches, "BranchID", "BranchName", assetTransfer.ToBranchID);
            return View(assetTransfer);
        }

        // POST: AssetTransfers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransferID,FromBranchID,ToBranchID,ItemID,Quantity,DateTransferred,Status,AssetTransferAuthorizedByUserID")] AssetTransfer assetTransfer)
        {
            if (id != assetTransfer.TransferID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assetTransfer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetTransferExists(assetTransfer.TransferID))
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
            ViewData["AssetTransferAuthorizedByUserID"] = new SelectList(_context.Users, "UserID", "Role", assetTransfer.AssetTransferAuthorizedByUserID);
            ViewData["FromBranchID"] = new SelectList(_context.Branches, "BranchID", "BranchName", assetTransfer.FromBranchID);
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "Description", assetTransfer.ItemID);
            ViewData["ToBranchID"] = new SelectList(_context.Branches, "BranchID", "BranchName", assetTransfer.ToBranchID);
            return View(assetTransfer);
        }

        // GET: AssetTransfers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetTransfer = await _context.AssetTransfers
                .Include(a => a.AssetTransferAuthorizedByUser)
                .Include(a => a.FromBranch)
                .Include(a => a.Item)
                .Include(a => a.ToBranch)
                .FirstOrDefaultAsync(m => m.TransferID == id);
            if (assetTransfer == null)
            {
                return NotFound();
            }

            return View(assetTransfer);
        }

        // POST: AssetTransfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assetTransfer = await _context.AssetTransfers.FindAsync(id);
            if (assetTransfer != null)
            {
                _context.AssetTransfers.Remove(assetTransfer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetTransferExists(int id)
        {
            return _context.AssetTransfers.Any(e => e.TransferID == id);
        }
    }
}

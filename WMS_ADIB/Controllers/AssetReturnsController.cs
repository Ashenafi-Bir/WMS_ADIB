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
    public class AssetReturnsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssetReturnsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AssetReturns
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AssetReturns.Include(a => a.AssetReturnApprovedBy).Include(a => a.AssetReturnReceivedBy).Include(a => a.Branch).Include(a => a.Item);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AssetReturns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetReturn = await _context.AssetReturns
                .Include(a => a.AssetReturnApprovedBy)
                .Include(a => a.AssetReturnReceivedBy)
                .Include(a => a.Branch)
                .Include(a => a.Item)
                .FirstOrDefaultAsync(m => m.ReturnID == id);
            if (assetReturn == null)
            {
                return NotFound();
            }

            return View(assetReturn);
        }

        // GET: AssetReturns/Create
        public IActionResult Create()
        {
            ViewData["AssetReturnApprovedByID"] = new SelectList(_context.Users, "UserID", "Role");
            ViewData["AssetReturnReceivedByID"] = new SelectList(_context.Users, "UserID", "Role");
            ViewData["BranchID"] = new SelectList(_context.Branches, "BranchID", "BranchName");
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "Description");
            return View();
        }

        // POST: AssetReturns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReturnID,BranchID,ItemID,DateReturned,Status,AssetReturnReceivedByID,AssetReturnApprovedByID")] AssetReturn assetReturn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assetReturn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetReturnApprovedByID"] = new SelectList(_context.Users, "UserID", "Role", assetReturn.AssetReturnApprovedByID);
            ViewData["AssetReturnReceivedByID"] = new SelectList(_context.Users, "UserID", "Role", assetReturn.AssetReturnReceivedByID);
            ViewData["BranchID"] = new SelectList(_context.Branches, "BranchID", "BranchName", assetReturn.BranchID);
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "Description", assetReturn.ItemID);
            return View(assetReturn);
        }

        // GET: AssetReturns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetReturn = await _context.AssetReturns.FindAsync(id);
            if (assetReturn == null)
            {
                return NotFound();
            }
            ViewData["AssetReturnApprovedByID"] = new SelectList(_context.Users, "UserID", "Role", assetReturn.AssetReturnApprovedByID);
            ViewData["AssetReturnReceivedByID"] = new SelectList(_context.Users, "UserID", "Role", assetReturn.AssetReturnReceivedByID);
            ViewData["BranchID"] = new SelectList(_context.Branches, "BranchID", "BranchName", assetReturn.BranchID);
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "Description", assetReturn.ItemID);
            return View(assetReturn);
        }

        // POST: AssetReturns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReturnID,BranchID,ItemID,DateReturned,Status,AssetReturnReceivedByID,AssetReturnApprovedByID")] AssetReturn assetReturn)
        {
            if (id != assetReturn.ReturnID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assetReturn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetReturnExists(assetReturn.ReturnID))
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
            ViewData["AssetReturnApprovedByID"] = new SelectList(_context.Users, "UserID", "Role", assetReturn.AssetReturnApprovedByID);
            ViewData["AssetReturnReceivedByID"] = new SelectList(_context.Users, "UserID", "Role", assetReturn.AssetReturnReceivedByID);
            ViewData["BranchID"] = new SelectList(_context.Branches, "BranchID", "BranchName", assetReturn.BranchID);
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "Description", assetReturn.ItemID);
            return View(assetReturn);
        }

        // GET: AssetReturns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetReturn = await _context.AssetReturns
                .Include(a => a.AssetReturnApprovedBy)
                .Include(a => a.AssetReturnReceivedBy)
                .Include(a => a.Branch)
                .Include(a => a.Item)
                .FirstOrDefaultAsync(m => m.ReturnID == id);
            if (assetReturn == null)
            {
                return NotFound();
            }

            return View(assetReturn);
        }

        // POST: AssetReturns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assetReturn = await _context.AssetReturns.FindAsync(id);
            if (assetReturn != null)
            {
                _context.AssetReturns.Remove(assetReturn);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetReturnExists(int id)
        {
            return _context.AssetReturns.Any(e => e.ReturnID == id);
        }
    }
}

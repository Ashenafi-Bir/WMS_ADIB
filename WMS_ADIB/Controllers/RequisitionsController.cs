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
    public class RequisitionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequisitionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Requisitions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Requisitions.Include(r => r.Branch).Include(r => r.IssuedByUser).Include(r => r.Item).Include(r => r.RequisitionApprovedByUser).Include(r => r.RequisitionAuthorizedByUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Requisitions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisition = await _context.Requisitions
                .Include(r => r.Branch)
                .Include(r => r.IssuedByUser)
                .Include(r => r.Item)
                .Include(r => r.RequisitionApprovedByUser)
                .Include(r => r.RequisitionAuthorizedByUser)
                .FirstOrDefaultAsync(m => m.RequisitionID == id);
            if (requisition == null)
            {
                return NotFound();
            }

            return View(requisition);
        }

        // GET: Requisitions/Create
        public IActionResult Create()
        {
            ViewData["BranchID"] = new SelectList(_context.Branches, "BranchID", "BranchName");
            ViewData["IssuedByUserID"] = new SelectList(_context.Users, "UserID", "Role");
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "Description");
            ViewData["RequisitionApprovedByUserID"] = new SelectList(_context.Users, "UserID", "Role");
            ViewData["RequisitionAuthorizedByUserID"] = new SelectList(_context.Users, "UserID", "Role");
            return View();
        }

        // POST: Requisitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequisitionID,BranchID,ItemID,Quantity,DateRequested,DateApproved,DateDispatched,Status,RequisitionApprovedByUserID,RequisitionAuthorizedByUserID,IssuedByUserID")] Requisition requisition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requisition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchID"] = new SelectList(_context.Branches, "BranchID", "BranchName", requisition.BranchID);
            ViewData["IssuedByUserID"] = new SelectList(_context.Users, "UserID", "Role", requisition.IssuedByUserID);
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "Description", requisition.ItemID);
            ViewData["RequisitionApprovedByUserID"] = new SelectList(_context.Users, "UserID", "Role", requisition.RequisitionApprovedByUserID);
            ViewData["RequisitionAuthorizedByUserID"] = new SelectList(_context.Users, "UserID", "Role", requisition.RequisitionAuthorizedByUserID);
            return View(requisition);
        }

        // GET: Requisitions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisition = await _context.Requisitions.FindAsync(id);
            if (requisition == null)
            {
                return NotFound();
            }
            ViewData["BranchID"] = new SelectList(_context.Branches, "BranchID", "BranchName", requisition.BranchID);
            ViewData["IssuedByUserID"] = new SelectList(_context.Users, "UserID", "Role", requisition.IssuedByUserID);
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "Description", requisition.ItemID);
            ViewData["RequisitionApprovedByUserID"] = new SelectList(_context.Users, "UserID", "Role", requisition.RequisitionApprovedByUserID);
            ViewData["RequisitionAuthorizedByUserID"] = new SelectList(_context.Users, "UserID", "Role", requisition.RequisitionAuthorizedByUserID);
            return View(requisition);
        }

        // POST: Requisitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequisitionID,BranchID,ItemID,Quantity,DateRequested,DateApproved,DateDispatched,Status,RequisitionApprovedByUserID,RequisitionAuthorizedByUserID,IssuedByUserID")] Requisition requisition)
        {
            if (id != requisition.RequisitionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requisition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequisitionExists(requisition.RequisitionID))
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
            ViewData["BranchID"] = new SelectList(_context.Branches, "BranchID", "BranchName", requisition.BranchID);
            ViewData["IssuedByUserID"] = new SelectList(_context.Users, "UserID", "Role", requisition.IssuedByUserID);
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "Description", requisition.ItemID);
            ViewData["RequisitionApprovedByUserID"] = new SelectList(_context.Users, "UserID", "Role", requisition.RequisitionApprovedByUserID);
            ViewData["RequisitionAuthorizedByUserID"] = new SelectList(_context.Users, "UserID", "Role", requisition.RequisitionAuthorizedByUserID);
            return View(requisition);
        }

        // GET: Requisitions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisition = await _context.Requisitions
                .Include(r => r.Branch)
                .Include(r => r.IssuedByUser)
                .Include(r => r.Item)
                .Include(r => r.RequisitionApprovedByUser)
                .Include(r => r.RequisitionAuthorizedByUser)
                .FirstOrDefaultAsync(m => m.RequisitionID == id);
            if (requisition == null)
            {
                return NotFound();
            }

            return View(requisition);
        }

        // POST: Requisitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requisition = await _context.Requisitions.FindAsync(id);
            if (requisition != null)
            {
                _context.Requisitions.Remove(requisition);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequisitionExists(int id)
        {
            return _context.Requisitions.Any(e => e.RequisitionID == id);
        }
    }
}

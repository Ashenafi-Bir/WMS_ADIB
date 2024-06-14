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
    public class PurchaseOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchaseOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PurchaseOrders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PurchaseOrders.Include(p => p.PurchaseOrderAuthorizedBy).Include(p => p.PurchaseRequisition).Include(p => p.Supplier);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PurchaseOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = await _context.PurchaseOrders
                .Include(p => p.PurchaseOrderAuthorizedBy)
                .Include(p => p.PurchaseRequisition)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.POId == id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Create
        public IActionResult Create()
        {
            ViewData["PurchaseOrderAuthorizedByID"] = new SelectList(_context.Users, "UserID", "Role");
            ViewData["PRNumber"] = new SelectList(_context.PurchaseRequisitions, "PRNumber", "PRNumber");
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "InvoiceNumber");
            return View();
        }

        // POST: PurchaseOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("POId,PONumber,PRNumber,SupplierID,Date,PurchaseOrderOrderedByID,PurchaseOrderAuthorizedByID")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PurchaseOrderAuthorizedByID"] = new SelectList(_context.Users, "UserID", "Role", purchaseOrder.PurchaseOrderAuthorizedByID);
            ViewData["PRNumber"] = new SelectList(_context.PurchaseRequisitions, "PRNumber", "PRNumber", purchaseOrder.PRNumber);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "InvoiceNumber", purchaseOrder.SupplierID);
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = await _context.PurchaseOrders.FindAsync(id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }
            ViewData["PurchaseOrderAuthorizedByID"] = new SelectList(_context.Users, "UserID", "Role", purchaseOrder.PurchaseOrderAuthorizedByID);
            ViewData["PRNumber"] = new SelectList(_context.PurchaseRequisitions, "PRNumber", "PRNumber", purchaseOrder.PRNumber);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "InvoiceNumber", purchaseOrder.SupplierID);
            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("POId,PONumber,PRNumber,SupplierID,Date,PurchaseOrderOrderedByID,PurchaseOrderAuthorizedByID")] PurchaseOrder purchaseOrder)
        {
            if (id != purchaseOrder.POId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseOrderExists(purchaseOrder.POId))
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
            ViewData["PurchaseOrderAuthorizedByID"] = new SelectList(_context.Users, "UserID", "Role", purchaseOrder.PurchaseOrderAuthorizedByID);
            ViewData["PRNumber"] = new SelectList(_context.PurchaseRequisitions, "PRNumber", "PRNumber", purchaseOrder.PRNumber);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "InvoiceNumber", purchaseOrder.SupplierID);
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = await _context.PurchaseOrders
                .Include(p => p.PurchaseOrderAuthorizedBy)
                .Include(p => p.PurchaseRequisition)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.POId == id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseOrder = await _context.PurchaseOrders.FindAsync(id);
            if (purchaseOrder != null)
            {
                _context.PurchaseOrders.Remove(purchaseOrder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseOrderExists(int id)
        {
            return _context.PurchaseOrders.Any(e => e.POId == id);
        }
    }
}

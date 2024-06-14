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
    public class GoodsReceivingNotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GoodsReceivingNotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GoodsReceivingNotes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GoodsReceivingNotes.Include(g => g.GRNDeliverUser).Include(g => g.GRNInspectUser).Include(g => g.GRNReceiveUser).Include(g => g.PurchaseOrder);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GoodsReceivingNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsReceivingNote = await _context.GoodsReceivingNotes
                .Include(g => g.GRNDeliverUser)
                .Include(g => g.GRNInspectUser)
                .Include(g => g.GRNReceiveUser)
                .Include(g => g.PurchaseOrder)
                .FirstOrDefaultAsync(m => m.GRNID == id);
            if (goodsReceivingNote == null)
            {
                return NotFound();
            }

            return View(goodsReceivingNote);
        }

        // GET: GoodsReceivingNotes/Create
        public IActionResult Create()
        {
            ViewData["GRNDeliverUserID"] = new SelectList(_context.Users, "UserID", "Role");
            ViewData["GRNInspectUserID"] = new SelectList(_context.Users, "UserID", "Role");
            ViewData["GRNReceiveUserID"] = new SelectList(_context.Users, "UserID", "Role");
            ViewData["PONumber"] = new SelectList(_context.PurchaseOrders, "POId", "POId");
            return View();
        }

        // POST: GoodsReceivingNotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GRNID,PONumber,DateReceived,GRNDeliverUserID,GRNInspectUserID,GRNReceiveUserID")] GoodsReceivingNote goodsReceivingNote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goodsReceivingNote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GRNDeliverUserID"] = new SelectList(_context.Users, "UserID", "Role", goodsReceivingNote.GRNDeliverUserID);
            ViewData["GRNInspectUserID"] = new SelectList(_context.Users, "UserID", "Role", goodsReceivingNote.GRNInspectUserID);
            ViewData["GRNReceiveUserID"] = new SelectList(_context.Users, "UserID", "Role", goodsReceivingNote.GRNReceiveUserID);
            ViewData["PONumber"] = new SelectList(_context.PurchaseOrders, "POId", "POId", goodsReceivingNote.PONumber);
            return View(goodsReceivingNote);
        }

        // GET: GoodsReceivingNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsReceivingNote = await _context.GoodsReceivingNotes.FindAsync(id);
            if (goodsReceivingNote == null)
            {
                return NotFound();
            }
            ViewData["GRNDeliverUserID"] = new SelectList(_context.Users, "UserID", "Role", goodsReceivingNote.GRNDeliverUserID);
            ViewData["GRNInspectUserID"] = new SelectList(_context.Users, "UserID", "Role", goodsReceivingNote.GRNInspectUserID);
            ViewData["GRNReceiveUserID"] = new SelectList(_context.Users, "UserID", "Role", goodsReceivingNote.GRNReceiveUserID);
            ViewData["PONumber"] = new SelectList(_context.PurchaseOrders, "POId", "POId", goodsReceivingNote.PONumber);
            return View(goodsReceivingNote);
        }

        // POST: GoodsReceivingNotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GRNID,PONumber,DateReceived,GRNDeliverUserID,GRNInspectUserID,GRNReceiveUserID")] GoodsReceivingNote goodsReceivingNote)
        {
            if (id != goodsReceivingNote.GRNID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goodsReceivingNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodsReceivingNoteExists(goodsReceivingNote.GRNID))
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
            ViewData["GRNDeliverUserID"] = new SelectList(_context.Users, "UserID", "Role", goodsReceivingNote.GRNDeliverUserID);
            ViewData["GRNInspectUserID"] = new SelectList(_context.Users, "UserID", "Role", goodsReceivingNote.GRNInspectUserID);
            ViewData["GRNReceiveUserID"] = new SelectList(_context.Users, "UserID", "Role", goodsReceivingNote.GRNReceiveUserID);
            ViewData["PONumber"] = new SelectList(_context.PurchaseOrders, "POId", "POId", goodsReceivingNote.PONumber);
            return View(goodsReceivingNote);
        }

        // GET: GoodsReceivingNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsReceivingNote = await _context.GoodsReceivingNotes
                .Include(g => g.GRNDeliverUser)
                .Include(g => g.GRNInspectUser)
                .Include(g => g.GRNReceiveUser)
                .Include(g => g.PurchaseOrder)
                .FirstOrDefaultAsync(m => m.GRNID == id);
            if (goodsReceivingNote == null)
            {
                return NotFound();
            }

            return View(goodsReceivingNote);
        }

        // POST: GoodsReceivingNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goodsReceivingNote = await _context.GoodsReceivingNotes.FindAsync(id);
            if (goodsReceivingNote != null)
            {
                _context.GoodsReceivingNotes.Remove(goodsReceivingNote);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodsReceivingNoteExists(int id)
        {
            return _context.GoodsReceivingNotes.Any(e => e.GRNID == id);
        }
    }
}

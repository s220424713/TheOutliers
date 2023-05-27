using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Outliers_E_Commerce.Areas.Identity.Data;
using Outliers_E_Commerce.Models;

namespace Outliers_E_Commerce.Controllers
{
    public class PurchaseRequest_VMController : Controller
    {
        private readonly ApplicationDBContext _context;

        public PurchaseRequest_VMController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: PurchaseRequest_VM
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.PurchaseRequest_VM.Include(p => p.Employee).Include(p => p.Products);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: PurchaseRequest_VM/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PurchaseRequest_VM == null)
            {
                return NotFound();
            }

            var purchaseRequest_VM = await _context.PurchaseRequest_VM
                .Include(p => p.Employee)
                .Include(p => p.Products)
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (purchaseRequest_VM == null)
            {
                return NotFound();
            }

            return View(purchaseRequest_VM);
        }

        // GET: PurchaseRequest_VM/Create
        public IActionResult Create()
        {
            ViewData["Employeeid"] = new SelectList(_context.Employee, "Employeeid", "Employeeid");
            ViewData["ProductID"] = new SelectList(_context.tblProduct, "ProductID", "Brand");
            return View();
        }

        // POST: PurchaseRequest_VM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestID,RequestDate,Employeeid,TotalAmount,status,PurchaseRID,ProductID,Quantity")] PurchaseRequest_VM purchaseRequest_VM)
        {
            if (ModelState.IsValid)
            {
                PurchaseRequest purchase_ = new PurchaseRequest();
                purchase_.RequestDate = DateTime.Today;
                purchase_.Employeeid = purchaseRequest_VM.Employeeid;
                purchase_.status = "Pending";
                _context.Add(purchase_);
                await _context.SaveChangesAsync();
                //Get the Latest Purchase Request
                var Purchse = _context.purchaseRequests.OrderByDescending(m => m.RequestID).FirstOrDefault();

                //Add the PurchaseR_Product
                PurchaseR_Detail purchaseR_ = new PurchaseR_Detail();
                purchaseR_.Products = purchaseRequest_VM.Products;
                purchaseR_.Quantity = purchaseRequest_VM.Quantity;
                purchaseR_.RequestID = purchase_.RequestID;
                _context.Add(purchaseR_);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

                _context.Add(purchaseRequest_VM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Employeeid"] = new SelectList(_context.Employee, "Employeeid", "Employeeid", purchaseRequest_VM.Employeeid);
            ViewData["ProductID"] = new SelectList(_context.tblProduct, "ProductID", "Brand", purchaseRequest_VM.ProductID);
            return View(purchaseRequest_VM);
        }

        // GET: PurchaseRequest_VM/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PurchaseRequest_VM == null)
            {
                return NotFound();
            }

            var purchaseRequest_VM = await _context.PurchaseRequest_VM.FindAsync(id);
            if (purchaseRequest_VM == null)
            {
                return NotFound();
            }
            ViewData["Employeeid"] = new SelectList(_context.Employee, "Employeeid", "Employeeid", purchaseRequest_VM.Employeeid);
            ViewData["ProductID"] = new SelectList(_context.tblProduct, "ProductID", "Brand", purchaseRequest_VM.ProductID);
            return View(purchaseRequest_VM);
        }

        // POST: PurchaseRequest_VM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestID,RequestDate,Employeeid,TotalAmount,status,PurchaseRID,ProductID,Quantity")] PurchaseRequest_VM purchaseRequest_VM)
        {
            if (id != purchaseRequest_VM.RequestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseRequest_VM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseRequest_VMExists(purchaseRequest_VM.RequestID))
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
            ViewData["Employeeid"] = new SelectList(_context.Employee, "Employeeid", "Employeeid", purchaseRequest_VM.Employeeid);
            ViewData["ProductID"] = new SelectList(_context.tblProduct, "ProductID", "Brand", purchaseRequest_VM.ProductID);
            return View(purchaseRequest_VM);
        }

        // GET: PurchaseRequest_VM/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PurchaseRequest_VM == null)
            {
                return NotFound();
            }

            var purchaseRequest_VM = await _context.PurchaseRequest_VM
                .Include(p => p.Employee)
                .Include(p => p.Products)
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (purchaseRequest_VM == null)
            {
                return NotFound();
            }

            return View(purchaseRequest_VM);
        }

        // POST: PurchaseRequest_VM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PurchaseRequest_VM == null)
            {
                return Problem("Entity set 'ApplicationDBContext.PurchaseRequest_VM'  is null.");
            }
            var purchaseRequest_VM = await _context.PurchaseRequest_VM.FindAsync(id);
            if (purchaseRequest_VM != null)
            {
                _context.PurchaseRequest_VM.Remove(purchaseRequest_VM);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseRequest_VMExists(int id)
        {
          return (_context.PurchaseRequest_VM?.Any(e => e.RequestID == id)).GetValueOrDefault();
        }
    }
}

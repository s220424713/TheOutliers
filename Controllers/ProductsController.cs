using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel;
using Microsoft.EntityFrameworkCore;
using Outliers_E_Commerce.Areas.Identity.Data;
using Outliers_E_Commerce.Models;
using Microsoft.AspNetCore.Authorization;
namespace Outliers_E_Commerce.Controllers
{
    [AllowAnonymous]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ProductsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
              return _context.tblProduct != null ? 
                          View(await _context.tblProduct.ToListAsync()) :
                          Problem("Entity set 'ApplicationDBContext.tblProduct'  is null.");
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tblProduct == null)
            {
                return NotFound();
            }

            var products = await _context.tblProduct
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {

            ViewBag.Categoryid = new SelectList(_context.tblCategory.ToList(), "Categoryid", "CategoryName");
            return View();
        }
        [HttpGet]
        public IActionResult Create_Catergory()
        {
            return View();
        }
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Create_Catergory(Category category)
        {
            if(ModelState.IsValid)
            {
                _context.tblCategory.Add(category);
                _context.SaveChanges();
            }
            return View();
        }
        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("ProductID,ProductName,Discription,Category,Brand,Price,ImageName")]*/ Products products,  IFormFile ImageFile)
        {

            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await ImageFile.CopyToAsync(memoryStream);
                        products.ImageData = memoryStream.ToArray();
                        products.ImageType = ImageFile.ContentType;

                    }
                }


                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categoryid = new SelectList(_context.tblCategory.ToList(), "Categoryid", "CategoryName");
            return View(products);
        }

  

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tblProduct == null)
            {
                return NotFound();
            }

            var products = await _context.tblProduct.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,Discription,Category,Brand,Price,ImageName")] Products products)
        {
            if (id != products.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.ProductID))
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
            return View(products);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tblProduct == null)
            {
                return NotFound();
            }

            var products = await _context.tblProduct
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tblProduct == null)
            {
                return Problem("Entity set 'ApplicationDBContext.tblProduct'  is null.");
            }
            var products = await _context.tblProduct.FindAsync(id);
            if (products != null)
            {
                _context.tblProduct.Remove(products);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
          return (_context.tblProduct?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }
    }
}

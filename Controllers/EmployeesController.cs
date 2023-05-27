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
    public class EmployeesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public EmployeesController(ApplicationDBContext context)
        {
            _context = context;
        }
        
        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.Employee.Include(e => e.ApplicationUser).Include(e => e.Departments);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.ApplicationUser)
                .Include(e => e.Departments)
                .FirstOrDefaultAsync(m => m.Employeeid == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["ID"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["DepartID"] = new SelectList(_context.Departments, "DepartID", "DepartID");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Employeeid,ID,")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID"] = new SelectList(_context.Users, "Id", "Id", employee.ID);
            ViewData["DepartID"] = new SelectList(_context.Departments, "DepartID", "DepartID", employee.Departments);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["ID"] = new SelectList(_context.Users, "Id", "Id", employee.ID);
            ViewData["DepartID"] = new SelectList(_context.Departments, "DepartID", "DepartID", employee.Departments);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Employeeid,ID,DepartID")] Employee employee)
        {
            if (id != employee.Employeeid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Employeeid))
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
            ViewData["ID"] = new SelectList(_context.Users, "Id", "Id", employee.ID);
            ViewData["DepId"] = new SelectList(_context.Departments, "DepId", "DepId", employee.Departments);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.ApplicationUser)
                .Include(e => e.Departments)
                .FirstOrDefaultAsync(m => m.Employeeid == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employee == null)
            {
                return Problem("Entity set 'ApplicationDBContext.Employee'  is null.");
            }
            var employee = await _context.Employee.FindAsync(id);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employee?.Any(e => e.Employeeid == id)).GetValueOrDefault();
        }
    }
}

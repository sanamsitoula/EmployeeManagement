using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
   public class DepartmentsController : Controller
        {
            private readonly AppDbContext _context;

            public DepartmentsController(AppDbContext context)
            {
                _context = context;
            }

            // GET: Departments
            public async Task<IActionResult> Index(string searchString)
            {
                var departments = from d in _context.Departments
                                  where d.Status && d.CreatedDate != default && d.CreatedBy != 0
                                  select d;

                if (!String.IsNullOrEmpty(searchString))
                {
                    departments = departments.Where(d => d.Name.Contains(searchString)
                                           || d.Address.Contains(searchString));
                }

                return View(await departments.ToListAsync());
            }

            // GET: Departments/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var department = await _context.Departments
                    .Include(d => d.Employees)
                    .FirstOrDefaultAsync(m => m.Id == id && m.Status && m.CreatedDate != default && m.CreatedBy != 0);
                if (department == null)
                {
                    return NotFound();
                }

                return View(department);
            }

            // GET: Departments/Create
            public IActionResult Create()
            {
                return View();
            }

        // POST: Departments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Address,Status")] Department department)
        {
            if (ModelState.IsValid)
            {
                department.CreatedDate = DateTime.Now;
                department.CreatedBy = 1; // Replace with actual user ID when you have authentication
                _context.Add(department);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Department created successfully.";
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = "Error creating department. Please check the form and try again.";
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == id && d.Status && d.CreatedDate != default && d.CreatedBy != 0);
                if (department == null)
                {
                    return NotFound();
                }
                return View(department);
            }

            // POST: Departments/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Status,CreatedDate,CreatedBy")] Department department)
            {
                if (id != department.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(department);
                        await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Department updated successfully.";
                }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!DepartmentExists(department.Id))
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
            TempData["ErrorMessage"] = "Error updating department. Please check the form and try again.";
            return View(department);
        }

            // GET: Departments/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var department = await _context.Departments
                    .FirstOrDefaultAsync(m => m.Id == id && m.Status && m.CreatedDate != default && m.CreatedBy != 0);
                if (department == null)
                {
                    return NotFound();
                }

                return View(department);
            }

            // POST: Departments/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var department = await _context.Departments.FindAsync(id);
                department.Status = false; // Soft delete
                await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Department deleted successfully.";
            return RedirectToAction(nameof(Index));
            }

            private bool DepartmentExists(int id)
            {
                return _context.Departments.Any(e => e.Id == id && e.Status && e.CreatedDate != default && e.CreatedBy != 0);
            }
        }
    
}

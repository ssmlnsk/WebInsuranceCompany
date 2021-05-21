using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebInsuranceCompany.Data;
using WebInsuranceCompany.Models;

namespace WebInsuranceCompany.Pages.RequestsAndFilters.Filters
{
    public class EmployeeFilterModel : PageModel
    {
        private readonly WebInsuranceCompany.Data.InsuranceCompanyContext _context;

        public EmployeeFilterModel(WebInsuranceCompany.Data.InsuranceCompanyContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get; set; }
        public Post Post { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = _context.Post.First(m => m.PostId == id);

            if (Post == null)
            {
                return NotFound();
            }
            Employee = await _context.Employee
                .Include(e => e.Post).Where(m => m.PostId == Post.PostId).ToListAsync();
            return Page();
        }
    }
}
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
    public class PoliciesDataFilterModel : PageModel
    {
        private readonly WebInsuranceCompany.Data.InsuranceCompanyContext _context;

        public PoliciesDataFilterModel(WebInsuranceCompany.Data.InsuranceCompanyContext context)
        {
            _context = context;
        }

        public IList<Policy> Policy { get; set; }
        public Policy Policy_ { get; set; }
        public async Task<IActionResult> OnGetAsync(string End)
        {

            if (End == null)
            {
                return NotFound();
            }

            Policy_ = _context.Policy.First(m => m.MarkOfEnd == End);

            if (Policy_ == null)
            {
                return NotFound();
            }
            Policy = await _context.Policy
                .Include(e => e.PolicyId).Where(m => m.MarkOfEnd == Policy_.MarkOfEnd).ToListAsync();
            return Page();
        }
    }
}

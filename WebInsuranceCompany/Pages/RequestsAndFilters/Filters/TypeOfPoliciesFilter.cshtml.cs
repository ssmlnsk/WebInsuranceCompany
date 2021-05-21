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
    public class TypeOfPoliciesFilterModel : PageModel
    {
        private readonly WebInsuranceCompany.Data.InsuranceCompanyContext _context;

        public TypeOfPoliciesFilterModel(WebInsuranceCompany.Data.InsuranceCompanyContext context)
        {
            _context = context;
        }

        public IList<Policy> Policy { get; set; }
        public TypeOfPolicy TypeOfPolicy { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            TypeOfPolicy = _context.TypeOfPolicy.First(m => m.TypeOfPolicyId == id);

            if (TypeOfPolicy == null)
            {
                return NotFound();
            }
            Policy = await _context.Policy
                .Include(e => e.TypeOfPolicy).Where(m => m.TypeOfPolicyId == TypeOfPolicy.TypeOfPolicyId).ToListAsync();
            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebInsuranceCompany.Data;
using WebInsuranceCompany.Models;

namespace WebInsuranceCompany.Pages.Policies
{
    public class DetailsModel : PageModel
    {
        private readonly WebInsuranceCompany.Data.InsuranceCompanyContext _context;

        public DetailsModel(WebInsuranceCompany.Data.InsuranceCompanyContext context)
        {
            _context = context;
        }

        public Policy Policy { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Policy = await _context.Policy
                .Include(p => p.Client)
                .Include(p => p.Employee)
                .Include(p => p.TypeOfPolicy).FirstOrDefaultAsync(m => m.PolicyId == id);

            if (Policy == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

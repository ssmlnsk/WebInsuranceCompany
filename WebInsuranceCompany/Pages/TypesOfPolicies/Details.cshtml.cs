using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebInsuranceCompany.Data;
using WebInsuranceCompany.Models;

namespace WebInsuranceCompany.Pages.TypesOfPolicies
{
    public class DetailsModel : PageModel
    {
        private readonly WebInsuranceCompany.Data.InsuranceCompanyContext _context;

        public DetailsModel(WebInsuranceCompany.Data.InsuranceCompanyContext context)
        {
            _context = context;
        }

        public TypeOfPolicy TypeOfPolicy { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TypeOfPolicy = await _context.TypeOfPolicy
                .Include(t => t.RiskId1Navigation)
                .Include(t => t.RiskId2Navigation)
                .Include(t => t.RiskId3Navigation).FirstOrDefaultAsync(m => m.TypeOfPolicyId == id);

            if (TypeOfPolicy == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

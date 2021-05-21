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
    public class PaymentMarkFilterModel : PageModel
    {
        private readonly WebInsuranceCompany.Data.InsuranceCompanyContext _context;

        public PaymentMarkFilterModel(WebInsuranceCompany.Data.InsuranceCompanyContext context)
        {
            _context = context;
        }

        public IList<Policy> Policy { get; set; }
        public Policy Policy_ { get; set; }
        public async Task<IActionResult> OnGetAsync(string Mark)
        {

            if (Mark == null)
            {
                return NotFound();
            }

            Policy_ = _context.Policy.First(m => m.PaymentMark == Mark);

            if (Policy_ == null)
            {
                return NotFound();
            }
            Policy = await _context.Policy
                 .Include(e => e.PolicyId).Where(m => m.PaymentMark == Policy_.PaymentMark).ToListAsync();
            return Page();
        }
    }
}

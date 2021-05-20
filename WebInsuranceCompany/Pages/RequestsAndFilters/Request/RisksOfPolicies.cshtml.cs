using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebInsuranceCompany.Data;
using WebInsuranceCompany.Models;

namespace WebInsuranceCompany.Pages.RequestsAndFilters.Request
{
    public class RisksOfPoliciesModel : PageModel
    {
        private readonly WebInsuranceCompany.Data.InsuranceCompanyContext _context;

        public RisksOfPoliciesModel(WebInsuranceCompany.Data.InsuranceCompanyContext context)
        {
            _context = context;
        }

        public IList<TypeOfPolicy> TypeOfPolicy { get; set; }
        public IList<Risk> Risk { get; set; }
        public async Task OnGetAsync()
        {
            TypeOfPolicy = await _context.TypeOfPolicy.ToListAsync();
            Risk = await _context.Risk.ToListAsync();
        }
    }
}

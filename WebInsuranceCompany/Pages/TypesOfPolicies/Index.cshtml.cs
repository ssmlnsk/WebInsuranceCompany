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
    public class IndexModel : PageModel
    {
        private readonly WebInsuranceCompany.Data.InsuranceCompanyContext _context;

        public IndexModel(WebInsuranceCompany.Data.InsuranceCompanyContext context)
        {
            _context = context;
        }

        public IList<TypeOfPolicy> TypeOfPolicy { get;set; }

        public async Task OnGetAsync()
        {
            TypeOfPolicy = await _context.TypeOfPolicy
                .Include(t => t.RiskId1Navigation)
                .Include(t => t.RiskId2Navigation)
                .Include(t => t.RiskId3Navigation).ToListAsync();
        }
    }
}

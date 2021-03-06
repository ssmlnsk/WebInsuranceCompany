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
    public class IndexModel : PageModel
    {
        private readonly WebInsuranceCompany.Data.InsuranceCompanyContext _context;

        public IndexModel(WebInsuranceCompany.Data.InsuranceCompanyContext context)
        {
            _context = context;
        }

        public IList<Policy> Policy { get;set; }

        public async Task OnGetAsync()
        {
            Policy = await _context.Policy
                .Include(p => p.Client)
                .Include(p => p.Employee)
                .Include(p => p.TypeOfPolicy).ToListAsync();
        }
    }
}

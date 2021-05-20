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
    public class ListOfPoliciesModel : PageModel
    {
        private readonly WebInsuranceCompany.Data.InsuranceCompanyContext _context;

        public ListOfPoliciesModel(WebInsuranceCompany.Data.InsuranceCompanyContext context)
        {
            _context = context;
        }

        public IList<Policy> Policy { get; set; }
        public IList<TypeOfPolicy> TypeOfPolicy { get; set; }
        public IList<Client> Client { get; set; }
        public IList<Employee> Employee { get; set; }
        public async Task OnGetAsync()
        {
            Policy = await _context.Policy.ToListAsync();
            TypeOfPolicy = await _context.TypeOfPolicy.ToListAsync();
            Client = await _context.Client.ToListAsync();
            Employee = await _context.Employee.ToListAsync();
        }
    }
}

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
    public class PersonnelDepartmentModel : PageModel
    {
        private readonly WebInsuranceCompany.Data.InsuranceCompanyContext _context;

        public PersonnelDepartmentModel(WebInsuranceCompany.Data.InsuranceCompanyContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get; set; }
        public IList<Post> Post { get; set; }
        public async Task OnGetAsync()
        {
            Employee = await _context.Employee.ToListAsync();
            Post = await _context.Post.ToListAsync();
        }
    }
}


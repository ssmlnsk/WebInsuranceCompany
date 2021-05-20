using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebInsuranceCompany.Data;
using WebInsuranceCompany.Models;

namespace WebInsuranceCompany.Pages.Policies
{
    public class CreateModel : PageModel
    {
        private readonly WebInsuranceCompany.Data.InsuranceCompanyContext _context;

        public CreateModel(WebInsuranceCompany.Data.InsuranceCompanyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Address");
        ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "Address");
        ViewData["TypeOfPolicyId"] = new SelectList(_context.TypeOfPolicy, "TypeOfPolicyId", "Conditions");
            return Page();
        }

        [BindProperty]
        public Policy Policy { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Policy.Add(Policy);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

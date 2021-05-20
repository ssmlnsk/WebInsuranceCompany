using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebInsuranceCompany.Data;
using WebInsuranceCompany.Models;

namespace WebInsuranceCompany.Pages.TypesOfPolicies
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
        ViewData["RiskId1"] = new SelectList(_context.Risk, "RiskId", "Description");
        ViewData["RiskId2"] = new SelectList(_context.Risk, "RiskId", "Description");
        ViewData["RiskId3"] = new SelectList(_context.Risk, "RiskId", "Description");
            return Page();
        }

        [BindProperty]
        public TypeOfPolicy TypeOfPolicy { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TypeOfPolicy.Add(TypeOfPolicy);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebInsuranceCompany.Data;
using WebInsuranceCompany.Models;

namespace WebInsuranceCompany.Pages.TypesOfPolicies
{
    public class EditModel : PageModel
    {
        private readonly WebInsuranceCompany.Data.InsuranceCompanyContext _context;

        public EditModel(WebInsuranceCompany.Data.InsuranceCompanyContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["RiskId1"] = new SelectList(_context.Risk, "RiskId", "Description");
           ViewData["RiskId2"] = new SelectList(_context.Risk, "RiskId", "Description");
           ViewData["RiskId3"] = new SelectList(_context.Risk, "RiskId", "Description");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TypeOfPolicy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeOfPolicyExists(TypeOfPolicy.TypeOfPolicyId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TypeOfPolicyExists(long id)
        {
            return _context.TypeOfPolicy.Any(e => e.TypeOfPolicyId == id);
        }
    }
}

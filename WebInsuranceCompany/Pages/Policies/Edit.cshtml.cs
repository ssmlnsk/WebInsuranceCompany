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

namespace WebInsuranceCompany.Pages.Policies
{
    public class EditModel : PageModel
    {
        private readonly WebInsuranceCompany.Data.InsuranceCompanyContext _context;

        public EditModel(WebInsuranceCompany.Data.InsuranceCompanyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Policy Policy { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Policy = await _context.Policy
                .Include(p => p.Client)
                .Include(p => p.Employee)
                .Include(p => p.TypeOfPolicy).FirstOrDefaultAsync(m => m.PolicyId == id);

            if (Policy == null)
            {
                return NotFound();
            }
           ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Address");
           ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "Address");
           ViewData["TypeOfPolicyId"] = new SelectList(_context.TypeOfPolicy, "TypeOfPolicyId", "Conditions");
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

            _context.Attach(Policy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyExists(Policy.PolicyId))
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

        private bool PolicyExists(long id)
        {
            return _context.Policy.Any(e => e.PolicyId == id);
        }
    }
}

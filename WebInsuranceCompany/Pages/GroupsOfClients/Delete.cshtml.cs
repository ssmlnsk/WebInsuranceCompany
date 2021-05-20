using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebInsuranceCompany.Data;
using WebInsuranceCompany.Models;

namespace WebInsuranceCompany.Pages.GroupsOfClients
{
    public class DeleteModel : PageModel
    {
        private readonly WebInsuranceCompany.Data.InsuranceCompanyContext _context;

        public DeleteModel(WebInsuranceCompany.Data.InsuranceCompanyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GroupOfClients GroupOfClients { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GroupOfClients = await _context.GroupOfClients.FirstOrDefaultAsync(m => m.GroupId == id);

            if (GroupOfClients == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GroupOfClients = await _context.GroupOfClients.FindAsync(id);

            if (GroupOfClients != null)
            {
                _context.GroupOfClients.Remove(GroupOfClients);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

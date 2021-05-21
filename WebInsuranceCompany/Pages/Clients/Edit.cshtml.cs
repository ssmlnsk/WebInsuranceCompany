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

namespace WebInsuranceCompany.Pages.Clients
{
    public class EditModel : PageModel
    {
        private readonly WebInsuranceCompany.Data.InsuranceCompanyContext _context;

        public EditModel(WebInsuranceCompany.Data.InsuranceCompanyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Client Client { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client = await _context.Client
                .Include(c => c.Group).FirstOrDefaultAsync(m => m.ClientId == id);

            if (Client == null)
            {
                return NotFound();
            }
           ViewData["GroupId"] = new SelectList(_context.GroupOfClients, "GroupId", "Name");
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

            _context.Attach(Client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(Client.ClientId))
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

        private bool ClientExists(long id)
        {
            return _context.Client.Any(e => e.ClientId == id);
        }
    }
}

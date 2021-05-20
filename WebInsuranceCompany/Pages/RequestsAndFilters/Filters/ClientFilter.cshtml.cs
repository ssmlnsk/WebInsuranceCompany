using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebInsuranceCompany.Data;
using WebInsuranceCompany.Models;

namespace WebInsuranceCompany.Pages.RequestsAndFilters.Filters
{
    public class ClientModel : PageModel
    {
        private readonly WebInsuranceCompany.Data.InsuranceCompanyContext _context;

        public ClientModel(WebInsuranceCompany.Data.InsuranceCompanyContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get; set; }
        public GroupOfClients Groups { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Groups = await _context.GroupOfClients.FirstOrDefaultAsync(m => m.GroupId == id);

            if (Groups == null)
            {
                return NotFound();
            }
            Client = await _context.Client.Where(m => m.GroupId == Groups.GroupId).ToListAsync();
            return Page();
        }
    }
}

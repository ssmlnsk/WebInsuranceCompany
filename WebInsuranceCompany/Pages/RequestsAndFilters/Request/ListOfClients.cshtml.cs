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
    public class ListOfClientsModel : PageModel
    {
        private readonly WebInsuranceCompany.Data.InsuranceCompanyContext _context;

        public ListOfClientsModel(WebInsuranceCompany.Data.InsuranceCompanyContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get; set; }
        public IList<GroupOfClients> GroupOfClients { get; set; }
        public async Task OnGetAsync()
        {
            Client = await _context.Client.ToListAsync();
            GroupOfClients = await _context.GroupOfClients.ToListAsync();
        }
    }
}

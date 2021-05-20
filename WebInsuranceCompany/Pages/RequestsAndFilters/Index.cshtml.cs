using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebInsuranceCompany.Pages.RequestsAndFilters
{
    public class IndexModel : PageModel
    {
        private readonly WebInsuranceCompany.Data.InsuranceCompanyContext _context;

        public IndexModel(WebInsuranceCompany.Data.InsuranceCompanyContext context)
        {
            _context = context;
        }
        public List<SelectListItem> Post { get; set; }
        public List<SelectListItem> Client { get; set; }
        public List<SelectListItem> Type { get; set; }
        public List<SelectListItem> Mark { get; set; }
        public List<SelectListItem> Data { get; set; }

        public IActionResult OnGet()
        {
            Post = _context.Post.Select(p =>
                new SelectListItem
                {
                    Value = p.PostId.ToString(),
                    Text = p.Name
                }).ToList();

            Client = _context.GroupOfClients.Select(p =>
               new SelectListItem
               {
                   Value = p.GroupId.ToString(),
                   Text = p.Name
               }).ToList();

            Type = _context.TypeOfPolicy.Select(p =>
               new SelectListItem
               {
                   Value = p.TypeOfPolicyId.ToString(),
                   Text = p.Name
               }).ToList();

            Mark = _context.Policy.Select(p =>
               new SelectListItem
               {
                   Value = p.PaymentMark.ToString(),
                   Text = p.PaymentMark
               }).ToList();

            Data = _context.Policy.Select(p =>
              new SelectListItem
              {
                  Value = p.MarkOfEnd.ToString(),
                  Text = p.MarkOfEnd
              }).ToList();

            return Page();
        }

    }
}

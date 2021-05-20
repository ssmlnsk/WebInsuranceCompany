using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebInsuranceCompany.Models
{
    public partial class GroupOfClients
    {
        public GroupOfClients()
        {
            Client = new HashSet<Client>();
        }

        [Display(Name = "Код группы клиентов")]
        public long GroupId { get; set; }
        [Display(Name = "Наименование группы")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }

        public virtual ICollection<Client> Client { get; set; }
    }
}

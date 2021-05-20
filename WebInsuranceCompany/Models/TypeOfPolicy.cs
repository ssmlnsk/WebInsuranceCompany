using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebInsuranceCompany.Models
{
    public partial class TypeOfPolicy
    {
        public TypeOfPolicy()
        {
            Policy = new HashSet<Policy>();
        }

        [Display(Name = "Код вида полиса")]
        public long TypeOfPolicyId { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Условия")]
        public string Conditions { get; set; }
        [Display(Name = "Риск 1")]
        public long RiskId1 { get; set; }
        [Display(Name = "Риск 2")]
        public long RiskId2 { get; set; }
        [Display(Name = "Риск 3")]
        public long RiskId3 { get; set; }
        [Display(Name = "Риск 1")]
        public virtual Risk RiskId1Navigation { get; set; }
        [Display(Name = "Риск 2")]
        public virtual Risk RiskId2Navigation { get; set; }
        [Display(Name = "Риск 3")]
        public virtual Risk RiskId3Navigation { get; set; }
        public virtual ICollection<Policy> Policy { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebInsuranceCompany.Models
{
    public partial class Risk
    {
        public Risk()
        {
            TypeOfPolicyRiskId1Navigation = new HashSet<TypeOfPolicy>();
            TypeOfPolicyRiskId2Navigation = new HashSet<TypeOfPolicy>();
            TypeOfPolicyRiskId3Navigation = new HashSet<TypeOfPolicy>();
        }

        [Display(Name = "Код риска")]
        public long RiskId { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Средняя вероятность")]
        public double AverageProbability { get; set; }

        public virtual ICollection<TypeOfPolicy> TypeOfPolicyRiskId1Navigation { get; set; }
        public virtual ICollection<TypeOfPolicy> TypeOfPolicyRiskId2Navigation { get; set; }
        public virtual ICollection<TypeOfPolicy> TypeOfPolicyRiskId3Navigation { get; set; }
    }
}

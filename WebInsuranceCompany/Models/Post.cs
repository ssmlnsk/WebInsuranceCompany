using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebInsuranceCompany.Models
{
    public partial class Post
    {
        public Post()
        {
            Employee = new HashSet<Employee>();
        }

        [Display(Name = "Код должности")]
        public long PostId { get; set; }
        [Display(Name = "Наименование должности")]
        public string Name { get; set; }
        [Display(Name = "Требования")]
        public string Requirements { get; set; }
        [Display(Name = "Оклад")]
        public long Salary { get; set; }
        [Display(Name = "Обязанности")]
        public string Responsibilities { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}

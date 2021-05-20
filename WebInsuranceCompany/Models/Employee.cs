using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebInsuranceCompany.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Policy = new HashSet<Policy>();
        }

        [Display(Name = "Код сотрудника")]
        public long EmployeeId { get; set; }
        [Display(Name = "ФИО")]
        public string FullName { get; set; }
        [Display(Name = "Возраст")]
        public long Age { get; set; }
        [Display(Name = "Пол")]
        public string Gender { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        [Display(Name = "Паспортные данные")]
        public string PassportData { get; set; }
        [Display(Name = "Должность")]
        public long PostId { get; set; }
        [Display(Name = "Должность")]
        public virtual Post Post { get; set; }
        public virtual ICollection<Policy> Policy { get; set; }
    }
}

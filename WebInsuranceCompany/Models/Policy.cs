using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebInsuranceCompany.Models
{
    public partial class Policy
    {
        [Display(Name = "Номер полиса")]
        public long PolicyId { get; set; }
        [Display(Name = "Дата начала")]
        public DateTime DateOfStart { get; set; }
        [Display(Name = "Дата окончания")]
        public DateTime DateOfFinish { get; set; }
        [Display(Name = "Стоимость")]
        public long Cost { get; set; }
        [Display(Name = "Сумма выплаты")]
        public long PaymentAmount { get; set; }
        [Display(Name = "Отметка о выплате")]
        public string PaymentMark { get; set; }
        [Display(Name = "Отметка об окончании")]
        public string MarkOfEnd { get; set; }
        [Display(Name = "Клиент")]
        public long? ClientId { get; set; }
        [Display(Name = "Вид полиса")]
        public long TypeOfPolicyId { get; set; }
        [Display(Name = "Сотрудник")]
        public long EmployeeId { get; set; }
        [Display(Name = "Клиент")]
        public virtual Client Client { get; set; }
        [Display(Name = "Сотрудник")]
        public virtual Employee Employee { get; set; }
        [Display(Name = "Вид полиса")]
        public virtual TypeOfPolicy TypeOfPolicy { get; set; }
    }
}

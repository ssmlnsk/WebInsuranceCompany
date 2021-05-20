using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebInsuranceCompany.Models
{
    public partial class Client
    {
        public Client()
        {
            Policy = new HashSet<Policy>();
        }
        [Display(Name ="Код клиента")]
        public long ClientId { get; set; }
        [Display(Name = "ФИО")]
        public string FullName { get; set; }
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Пол")]
        public string Gender { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        [Display(Name = "Паспортные данные")]
        public string PassportData { get; set; }
        [Display(Name = "Группа клиентов")]
        public long GroupId { get; set; }
        [Display(Name = "Группа клиентов")]
        public virtual GroupOfClients Group { get; set; }
        public virtual ICollection<Policy> Policy { get; set; }
    }
}

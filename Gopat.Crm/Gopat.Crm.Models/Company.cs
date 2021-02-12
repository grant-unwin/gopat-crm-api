using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Gopat.Crm.Models.Base;
using Gopat.Crm.Models.Enums;
using Gopat.Crm.Models.Owned;

namespace Gopat.Crm.Models
{
    public class Company : IdEntity
    {
        public Company()
        {
            Contacts = new List<Contact>();
            Sites = new List<Site>();
            Contracts = new List<Contract>();
        }

        [Required]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [DisplayName("Trading Style")]
        public TradingStyle TradingStyle { get; set; }

        public string RegistrationNumber { get; set; }

        public Address Address { get; set; }

        public ICollection<Contact> Contacts { get; set; }

        public ICollection<Site> Sites { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}

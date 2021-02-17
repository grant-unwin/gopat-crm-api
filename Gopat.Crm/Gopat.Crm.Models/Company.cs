using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
        public ICollection<TestSlot> TestSlots { get; set; }

        public List<TestSlot> GetTestSlots(TestSlotResult result)
        {
            return TestSlots == null ? new List<TestSlot>() : TestSlots.Where(s => s.TestSlowResult == result).ToList();
        }

        public List<TestSlot> GetFailedTestSlots()
        {
            return TestSlots == null ? new List<TestSlot>() : TestSlots.Where(s => s.TestSlowResult != TestSlotResult.Pending && s.TestSlowResult != TestSlotResult.Completed).ToList();
        }



    }
}

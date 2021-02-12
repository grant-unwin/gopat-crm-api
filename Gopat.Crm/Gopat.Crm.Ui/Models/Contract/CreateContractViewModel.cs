using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Gopat.Crm.Models.Owned;

namespace Gopat.Crm.Ui.Models.Contract
{
    public class CreateContractViewModel
    {
        public Guid CompanyId { get; set; }
        [DisplayName("Contract Length")]
        public int ContractLengthYears { get; set; }
        [DisplayName("Testing Interval")]
        public int IntervalMonths { get; set; }
        public DateTime StartDate { get; set; }
        public Price Price { get; set; }
        public Guid SignerContactId { get; set; }
    }
}

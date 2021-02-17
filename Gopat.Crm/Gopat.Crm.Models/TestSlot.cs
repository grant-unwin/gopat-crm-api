using System;
using System.Collections.Generic;
using System.Text;
using Gopat.Crm.Models.Base;
using Gopat.Crm.Models.Enums;
using Gopat.Crm.Models.Owned;

namespace Gopat.Crm.Models
{
    public class TestSlot : IdEntity
    {
        public TestSlot()
        {
            this.TestSlowResult = TestSlotResult.Pending;
        }

        public Guid SiteId { get; set; }
        public Site Site { get; set; }

        public Guid? ContractId { get; set; }
        public Contract Contract { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public DateTime ScheduledDateTime { get; set; }
        
        public int EstimatedDurationMins { get; set; }
        public int? ActualDurationMins { get; set; }

        public Price Price { get; set; }

        public int EstimatedAppliances { get; set; }
        public int ActualAppliances { get; set; }

        public TestSlotResult TestSlowResult { get; set; }


    }
}

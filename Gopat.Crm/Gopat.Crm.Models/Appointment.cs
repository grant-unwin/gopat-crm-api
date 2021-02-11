using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Gopat.Crm.Models.Base;
using Gopat.Crm.Models.Owned;

namespace Gopat.Crm.Models
{
    public class Appointment : IdEntity
    {
        public Guid SiteId { get; set; }
        public Site Site { get; set; }

        public Price Price { get; set; }

        /// <summary>
        /// The number of appliances expected to be tested
        /// </summary>
        public int ExpectedApplianceTotal { get; set; }

        /// <summary>
        /// The actual number of appliances tested
        /// </summary>
        public int? ApplianceTotal { get; set; }

        /// <summary>
        /// Whether the appointment was completed.
        /// </summary>
        public bool Completed { get; set; }

        /// <summary>
        /// Whether the appointment was cancelled.
        /// </summary>
        public bool Cancelled { get; set; }

        /// <summary>
        /// Whether the appointment was rescheduled.
        /// </summary>
        public bool Rescheduled { get; set; }

        public long ExpectedInvoiceTotal => (Price.CalloutFee) * (Price.ApplianceTestFee * ExpectedApplianceTotal);

        public long? InvoiceTotal => ApplianceTotal.HasValue ? (Price.CalloutFee) * (Price.ApplianceTestFee * ApplianceTotal) : null;
    }
}
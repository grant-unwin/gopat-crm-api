using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Gopat.Crm.Models.Base;

namespace Gopat.Crm.Models
{
    public class Contract : IdEntity
    {
        public int IntervalMonths { get; set; }
        public Price Price { get; set; }


        public Guid CompanyId { get; set; }

        public Company Company { get; set; }

        public Guid SiteId { get; set; }

        public Site Site { get; set; }

        public ICollection<Appointment> Appointments { get; set; }


    }
}
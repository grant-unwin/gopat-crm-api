using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Gopat.Crm.Models.Base;
using Gopat.Crm.Models.Owned;

namespace Gopat.Crm.Models
{
    public class Site : IdEntity
    {
        public Site()
        {
            Appointments = new List<Appointment>();
            Contracts = new List<Contract>();
        }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public Address Address { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}
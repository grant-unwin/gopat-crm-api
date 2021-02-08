using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Gopat.Crm.Models.Base;

namespace Gopat.Crm.Models
{
    public class Site : IdEntity
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }


        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}
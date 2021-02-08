using System;
using System.ComponentModel.DataAnnotations.Schema;
using Gopat.Crm.Models.Base;

namespace Gopat.Crm.Models
{
    public class Appointment : IdEntity
    {
        public Guid SiteId { get; set; }

        [ForeignKey("SiteId")]
        public Site Site { get; set; }

        public Guid? ContractId { get; set; }

        [ForeignKey("ContractId")]
        public Contract? Contract { get; set; }




        public Price Price { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Gopat.Crm.Models.Base;
using Gopat.Crm.Models.Enums;
using Gopat.Crm.Models.Owned;

namespace Gopat.Crm.Models
{
    public class Contact : IdEntity
    { 
        [DisplayName("Job Role")]
        public JobRole JobRole { get; set; }     
        public Person Person { get; set; }

        public EmailAddress EmailAddress { get; set; }
        public Telephone Telephone { get; set; }
        
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
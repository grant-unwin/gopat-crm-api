﻿using System.Collections.Generic;
using System.Text;
using Gopat.Crm.Models.Base;

namespace Gopat.Crm.Models
{
    public class Company : IdEntity
    {
        public string CompanyName { get; set; }

        public ICollection<Site> Sites { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}

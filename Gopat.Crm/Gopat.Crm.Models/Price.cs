using System;
using System.Collections.Generic;
using System.Text;
using Gopat.Crm.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace Gopat.Crm.Models
{
    [Owned]
    public class Price
    {
        public long CalloutFee { get; set; }
        public long ApplianceTestFee { get; set; }
    }
}

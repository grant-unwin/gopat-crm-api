using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Gopat.Crm.Models.Owned
{
    [Owned]
    public class EmailAddress
    {
        public string Address { get; set; }
    }
}

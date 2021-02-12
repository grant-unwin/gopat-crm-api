using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Gopat.Crm.Models.Owned
{
    [Owned]
    public class EmailAddress
    {
        [DisplayName("Email Address")]
        public string Address { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Gopat.Crm.Models.Owned
{
    [Owned]
    public class Telephone
    {
        public string Number { get; set; }
    }
}

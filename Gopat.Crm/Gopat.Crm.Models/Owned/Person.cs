using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Gopat.Crm.Models.Owned
{
    [Owned]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

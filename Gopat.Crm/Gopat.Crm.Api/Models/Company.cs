using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gopat.Crm.Api.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
    }
}

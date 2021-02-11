using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Gopat.Crm.Models.Owned
{
    [Owned]
    public class Address
    {
        [DisplayName("No")]
        public string BuildingNumberName { get; set; }
        [DisplayName("Street")]
        public string StreetName { get; set; }

        public string Area { get; set; }
        public string City { get; set; }

        public string Postcode { get; set; }
    }
}

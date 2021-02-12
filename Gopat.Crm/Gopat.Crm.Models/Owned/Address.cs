using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Gopat.Crm.Models.Owned
{
    [Owned]
    public class Price
    {
        [DisplayName("Callout Fee")]
        public long CalloutFee { get; set; }
        [DisplayName("App Fee")]
        public long ApplianceTestFee { get; set; }
    }
}
